using Engine.Abilities;
using Engine.Choices;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using Engine.Zones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    /// <summary>
    /// 102.1. A player is one of the people in the game.
    /// </summary>
    public abstract class Player : IPlayer, IDisposable
    {
        private static readonly Random Random = new();

        protected Player()
        {
            Id = Guid.NewGuid();
        }

        protected Player(IPlayer player)
        {
            Deck = new Deck(player.Deck);
            Graveyard = new Graveyard(player.Graveyard);
            Hand = new Hand(player.Hand);
            ManaZone = new ManaZone(player.ManaZone);
            ShieldZone = new ShieldZone(player.ShieldZone);
            Id = player.Id;
            Name = player?.Name;
        }

        public Guid AttackableId { get; set; }

        public IEnumerable<ICard> CardsInNonsharedZones
        {
            get
            {
                List<ICard> cards = new();
                cards.AddRange(Deck.Cards);
                cards.AddRange(Graveyard.Cards);
                cards.AddRange(Hand.Cards);
                cards.AddRange(ManaZone.Cards);
                cards.AddRange(ShieldZone.Cards);
                return cards;
            }
        }

        /// <summary>
        /// When a game begins, each player’s deck becomes their deck.
        /// </summary>
        public IDeck Deck { get; private set; } = new Deck();

        public bool DirectlyAttacked { get; set; }

        /// <summary>
        /// A player’s graveyard is their discard pile. Discarded cards, destroyed creatures and spells cast are put in their owner's graveyard.
        /// </summary>
        public Graveyard Graveyard { get; private set; } = new();

        /// <summary>
        /// The hand is where a player holds cards that have been drawn. Cards can be put into a player’s hand by other effects as well. At the beginning of the game, each player draws five cards.
        /// </summary>
        public Hand Hand { get; private set; } = new();

        public Guid Id { get; set; }

        /// <summary>
        /// The mana zone is where cards are put in order to produce mana for using other cards. All cards are put into the mana zone upside down. However, multicolored cards are put into the mana zone tapped.
        /// </summary>
        public IManaZone ManaZone { get; private set; } = new ManaZone();

        public string Name { get; set; }

        /// <summary>
        /// At the beginning of the game, each player puts five shields into their shield zone. Castles are put into the shield zone to fortify a shield.
        /// </summary>
        public ShieldZone ShieldZone { get; private set; } = new();

        public IEnumerable<IZone> Zones => new List<IZone> { Deck, Graveyard, Hand, ManaZone, ShieldZone };

        public void ArrangeTopCardsOfDeck(params ICard[] cards)
        {
            var arranged = Choose(new ArrangeChoice(this, cards)).Rearranged;
            Deck.Cards.RemoveAll(x => arranged.Contains(x));
            arranged.ToList().ForEach(x => Deck.Cards.Add(x));
        }

        public void Cast(ICard spell, IGame game)
        {
            game.ProcessEvents(new SpellCastEvent(this, spell));
        }

        public T Choose<T>(T choice) where T : Choice
        {
            T choiceMade;
            do
            {
                choiceMade = ChooseAbstractly(choice);
            } while (!choiceMade.IsValid());
            return choiceMade;
        }

        public IResolvableAbility ChooseAbility(IEnumerable<IResolvableAbility> abilities)
        {
            if (abilities.Count() == 1)
            {
                return abilities.Single();
            }
            else
            {
                return Choose(new AbilityChoice(this, abilities)).Choice;
            }
        }

        public abstract T ChooseAbstractly<T>(T choice) where T : Choice;

        public IEnumerable<ICard> ChooseAnyNumberOfCards(IEnumerable<ICard> cards, string description)
        {
            return ChooseCards(new CardChoice(this, description, new AnyNumberOfCardsChoiceMode(), cards.ToArray()));
        }

        public bool ChooseAttacker(IGame game, IEnumerable<ICard> attackers)
        {
            var minimum = attackers.Any(attacker => game.GetContinuousEffects<IAttacksIfAbleEffect>().Any(effect => effect.AttacksIfAble(attacker, game))) ? 1 : 0;
            var decision = ChooseCards(attackers, minimum, 1, "You may choose a creature to attack with.");
            if (decision.Any())
            {
                return ChooseAttackTarget(game, attackers, decision.Single().Id);
            }
            return false;
        }

        public IAttackable ChooseAttackTarget(IEnumerable<IAttackable> targets)
        {
            return Choose(new AttackTargetChoice(this, targets)).Choice;
        }

        public ICard ChooseCard(IEnumerable<ICard> cards, string description)
        {
            return ChooseCards(cards, 1, 1, description).SingleOrDefault();
        }

        public ICard ChooseCardOptionally(IEnumerable<ICard> cards, string description)
        {
            return ChooseCards(cards, 0, 1, description).SingleOrDefault();
        }

        public IEnumerable<ICard> ChooseCards(IEnumerable<ICard> cards, int min, int max, string description)
        {
            return ChooseCards(new CardChoice(this, description, new BoundedCardChoiceMode(min, max), cards.ToArray()));
        }

        public IEnumerable<ICard> ChooseCards(CardChoice choice)
        {
            if (choice.CanBeChosenAutomatically)
            {
                return choice.ChooseAutomatically();
            }
            else
            {
                return Choose(choice).Choice;
            }
        }

        public bool ChooseCardToUse(IGame game, IEnumerable<ICard> usableCards)
        {
            var toUse = ChooseCardOptionally(usableCards, "You may use a card from your hand.");
            if (toUse != null)
            {
                var manaCombinations = toUse.GetManaCombinations(this);
                if (manaCombinations.Count() > 1)
                {
                    ChooseCardsToPayManaCost(game, toUse);
                }
                else
                {
                    PayManaCostAndUseCard(game, manaCombinations.Single(), toUse);
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        public Civilization ChooseCivilization(string description, params Civilization[] excluded)
        {
            return Choose(new CivilizationChoice(this, description, excluded)).Choice.Value;
        }

        public ICard ChooseControlledCreature(IGame game, string description)
        {
            return ChooseCard(game.BattleZone.GetCreatures(Id), description);
        }

        public IEnumerable<ICard> ChooseControlledCreaturesOptionally(int max, IGame game, string description)
        {
            return ChooseCards(game.BattleZone.GetCreatures(Id), 0, max, description);
        }

        public int ChooseNumber(NumberChoice choice)
        {
            return Choose(choice).Choice.Value;
        }

        public ICard ChooseOpponentsCreature(IGame game, string description)
        {
            return ChooseCard(game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, game.GetOpponent(Id)), description);
        }

        public IPlayer ChoosePlayer(IGame game, string description)
        {
            return Choose(new PlayerChoice(this, description, game.Players)).Choice;
        }

        public Race ChooseRace(string description, params Race[] excluded)
        {
            return Choose(new RaceChoice(this, description, excluded)).Choice.Value;
        }

        public bool ChooseToTakeAction(string description)
        {
            return Choose(new BooleanChoice(this, description)).Choice.Value;
        }

        public abstract IPlayer Copy();

        public void Discard(IAbility ability, IGame game, params ICard[] cards)
        {
            _ = game.Move(ability, ZoneType.Hand, ZoneType.Graveyard, cards);
        }

        public void DiscardAtRandom(IGame game, int amount, IAbility ability)
        {
            if (Hand.HasCards)
            {
                _ = game.Move(ability, ZoneType.Hand, ZoneType.Graveyard, Hand.Cards.OrderBy(x => Guid.NewGuid()).Take(amount).ToArray());
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void DrawCards(int amount, IGame game, IAbility ability)
        {
            // 121.2. Cards may only be drawn one at a time.
            // If a player is instructed to draw multiple cards,
            // that player performs that many individual card draws.
            for (int i = 0; i < amount; ++i)
            {
                if (Deck.HasCards)
                {
                    game.Move(ability, ZoneType.Deck, ZoneType.Hand, Deck.Cards.Last());
                }
            }
        }

        public IEnumerable<ICard> GetCardsThatCanBePaidAndUsed(IGame game)
        {
            return GetCardsThatCanBePaid().Where(x => x.CanBeUsedRegardlessOfManaCost(game));
        }

        public IZone GetZone(ZoneType zone)
        {
            return zone switch
            {
                ZoneType.Deck => Deck,
                ZoneType.Graveyard => Graveyard,
                ZoneType.Hand => Hand,
                ZoneType.ManaZone => ManaZone,
                ZoneType.ShieldZone => ShieldZone,
                _ => throw new InvalidOperationException(),
            };
        }

        public void Look(IPlayer owner, IGame game, params ICard[] cards)
        {
            // 701.16d Some effects instruct a player to look at one or more cards.
            // Looking at a card follows the same rules as revealing a card,
            // except that the card is shown only to the specified player.
            owner.Reveal(game, new List<IPlayer> { this }, cards);
        }

        public void LookAtOpponentsHand(IGame game)
        {
            var cards = game.GetOpponent(this).Hand.Cards;
            if (cards.Any())
            {
                Look(game.GetOpponent(this), game, cards.ToArray());
                game.GetOpponent(this).Unreveal(cards);
            }
        }

        public IEnumerable<ICard> LookAtTheTopCardsOfYourDeck(int amount, IGame game)
        {
            var cards = Deck.GetTopCards(amount).ToArray();
            Look(this, game, cards);
            return cards;
        }

        public void PutFromTopOfDeckIntoManaZone(IGame game, int amount, IAbility ability)
        {
            for (int i = 0; i < amount; ++i)
            {
                if (Deck.HasCards)
                {
                    game.Move(ability, ZoneType.Deck, ZoneType.ManaZone, Deck.Cards.Last());
                }
            }
        }

        public void PutFromTopOfDeckIntoShieldZone(int amount, IGame game, IAbility ability)
        {
            for (int i = 0; i < amount; ++i)
            {
                if (Deck.HasCards)
                {
                    game.Move(ability, ZoneType.Deck, ZoneType.ShieldZone, Deck.Cards.Last());
                }
            }
        }

        public void PutOnTheBottomOfDeckInAnyOrder(ICard[] cards)
        {
            var arranged = Choose(new ArrangeChoice(this, cards)).Rearranged;
            Deck.Cards.RemoveAll(x => arranged.Contains(x));
            Deck.PutOnBottom(arranged);
        }

        /// <summary>
        /// 701.16a To reveal a card, show that card to all players for a brief time.
        /// If an effect causes a card to be revealed, it remains revealed for as long
        /// as necessary to complete the parts of the effect that card is relevant to.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="cards"></param>
        public void Reveal(IGame game, params ICard[] cards)
        {
            Reveal(game, game.Players, cards);
        }

        public void Reveal(IGame game, IEnumerable<IPlayer> players, params ICard[] cards)
        {
            // TODO: Implement reveal information on cards and add them here.
            cards.ToList().ForEach(x => x.KnownTo.AddRange(players.Select(x => x.Id)));
            //TODO: Event
            //game.Process(new RevealEvent { Revealer = Copy(), Cards = cards.Select(x => x.Convert()).ToList(), RevealedTo = players.Select(x => x.Copy()).ToList() });
        }

        public IEnumerable<ICard> RevealTopCardsOfDeck(int amount, IGame game)
        {
            var cards = Deck.GetTopCards(amount);
            Reveal(game, cards.ToArray());
            return cards;
        }

        public void ShuffleDeck(IGame game)
        {
            game.ProcessEvents(new ShuffleDeckEvent(this));
        }

        public void Tap(IGame game, params ICard[] cards)
        {
            var untappedCards = cards.Where(x => !x.Tapped && !game.GetContinuousEffects<IPlayerCannotTapCreatureEffect>().Any(e => e.PlayerCannotTapCreature(this, x, game))).ToList();
            foreach (var card in untappedCards)
            {
                card.Tapped = true;
            }
            if (untappedCards.Any())
            {
                //TODO: event
                //game.Process(new TapEvent(Convert(), untappedCards.Select(x => x.Convert()).ToList(), true));
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public void Unreveal(IEnumerable<ICard> cards)
        {
            // TODO: Implement reveal information on cards and remove them here.
        }

        public void Untap(IGame game, params ICard[] cards)
        {
            var tappedCards = cards.Where(x => x.Tapped).ToList();
            foreach (var card in tappedCards)
            {
                card.Tapped = false;
            }
            if (tappedCards.Any())
            {
                //TODO: event
                //game.Process(new TapEvent(Convert(), tappedCards.Select(x => x.Convert()).ToList(), false));
            }
        }

        public void UseCard(ICard card, IGame game)
        {
            game.CurrentTurn.CurrentPhase.UsedCards.Add(card.Copy());
            if (card.CardType == CardType.Creature)
            {
                if (card.Supertypes.Contains(Supertype.Evolution))
                {
                    Evolve(card, game);
                }
                Summon(card, game);
            }
            else if (card.CardType == CardType.Spell)
            {
                Cast(card, game);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        internal IEnumerable<ICard> GetCardsThatCanBePaid()
        {
            return Hand.Cards.Where(card => card.CanBePaid(this));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Deck?.Dispose();
                Deck = null;
                Graveyard?.Dispose();
                Graveyard = null;
                Hand?.Dispose();
                Hand = null;
                ManaZone?.Dispose();
                ManaZone = null;
                ShieldZone?.Dispose();
                ShieldZone = null;
            }
        }

        private bool ChooseAttackTarget(IGame game, IEnumerable<ICard> attackers, Guid id)
        {
            var attacker = attackers.Single(x => x.Id == id);
            var possibleTargets = game.GetPossibleAttackTargets(attacker);
            IAttackable target = possibleTargets.Count() > 1
                ? ChooseAttackTarget(possibleTargets)
                : possibleTargets.Single();
            Tap(game, attacker);
            if (target is ICard card && card.Id == attacker.Id)
            {
                game.AddPendingAbilities(attacker.GetAbilities<TapAbility>().Select(x => x.Copy()).Cast<IResolvableAbility>().ToArray());
                return true;
            }
            else
            {
                game.ProcessEvents(new CreatureAttackedEvent(attacker, target));
                return false;
            }
        }

        private void ChooseCardsToPayManaCost(IGame game, ICard toUse)
        {
            var manaDecision = ChooseCards(ManaZone.UntappedCards, toUse.ManaCost, toUse.ManaCost, "Choose cards to pay the mana cost with.");
            if (Card.HasCivilizations(manaDecision, toUse.Civilizations))
            {
                PayManaCostAndUseCard(game, manaDecision, toUse);
            }
            else
            {
                ChooseCardsToPayManaCost(game, toUse);
            }
        }

        /// <summary>
        /// 104.3a A player can concede the game at any time.
        /// A player who concedes leaves the game immediately.
        /// That player loses the game.
        /// </summary>
        /// <param name="game"></param>
        private void Concede(IGame game)
        {
            //TODO: event
            //game.Process(new ConcedeEvent { Player = Convert() });
            game.Lose(this);
        }

        private void Evolve(ICard card, IGame game)
        {
            var baits = game.GetCreaturesCreatureCanEvolveFrom(card);
            var bait = ChooseCard(baits, "Choose a creature to evolve from.");
            card.PutOnTopOf(bait);
        }

        private void PayManaCostAndUseCard(IGame game, IEnumerable<ICard> manaCards, ICard toUse)
        {
            Tap(game, manaCards.ToArray());
            UseCard(toUse, game);
        }

        private void Summon(ICard card, IGame game)
        {
            game.ProcessEvents(new CreatureSummonedEvent(this, card));
        }

        public ICard ChooseControlledCreatureOptionally(IGame game, string description, Civilization civilization)
        {
            return ChooseCards(game.BattleZone.GetCreatures(Id, civilization), 0, 1, description).SingleOrDefault();
        }

        public int DiscardAnyNumberOfCards(IGame game, IAbility ability)
        {
            var cards = ChooseAnyNumberOfCards(Hand.Cards, ability.ToString()).ToArray();
            Discard(ability, game, cards);
            return cards.Length;
        }

        public ICard DestroyOpponentsCreatureWithMaxPower(int power, IGame game, string description)
        {
            return ChooseCard(game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, game.GetOpponent(Id)).Where(x => x.Power <= power), description);
        }

        public ICard ChooseControlledCreatureOptionally(IGame game, string description)
        {
            return ChooseCards(game.BattleZone.GetCreatures(Id), 0, 1, description).SingleOrDefault();
        }

        public void BurnOwnMana(IGame game, IAbility ability)
        {
            var card = ChooseOwnMana(ability);
            game.Move(ability, ZoneType.ManaZone, ZoneType.Graveyard, card);
        }

        private ICard ChooseOwnMana(IAbility ability)
        {
            return ChooseCard(ManaZone.Cards, ability.ToString());
        }

        public void DiscardOwnCard(IGame game, IAbility ability)
        {
            var card = ChooseOwnHandCard(ability);
            game.Move(ability, ZoneType.Hand, ZoneType.Graveyard, card);
        }

        private ICard ChooseOwnHandCard(IAbility ability)
        {
            return ChooseCard(Hand.Cards, ability.ToString());
        }

        public void Sacrifice(IGame game, IAbility ability)
        {
            var creature = ChooseControlledCreature(game, ability.ToString());
            game.Destroy(ability, creature);
        }

        public void TapOpponentsCreature(IGame game)
        {
            Tap(game, ChooseOpponentsCreature(game, "Tap one of your opponent's creatures."));
        }

        public void ReturnOwnMana(IGame game, IAbility source)
        {
            game.Move(source, ZoneType.ManaZone, ZoneType.Hand, ChooseCard(ManaZone.Cards, source.ToString()));
        }

        public void PutOwnHandCardIntoMana(IGame game, IAbility source)
        {
            game.Move(source, ZoneType.Hand, ZoneType.ManaZone, ChooseCard(Hand.Cards, source.ToString()));
        }

        public ICard ChooseOpponentsNonEvolutionCreature(IGame game, string description)
        {
            return ChooseCard(game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, game.GetOpponent(Id)).Where(x => x.IsNonEvolutionCreature), description);
        }
    }
}