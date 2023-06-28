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

        protected Player(IGame game) : this()
        {
            Game = game;
        }

        protected Player(IPlayer player)
        {
            Deck = player.Deck.Copy();
            Graveyard = player.Graveyard.Copy();
            Hand = player.Hand.Copy();
            ManaZone = player.ManaZone.Copy();
            ShieldZone = player.ShieldZone.Copy();
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
        public IGraveyard Graveyard { get; private set; } = new Graveyard();

        /// <summary>
        /// The hand is where a player holds cards that have been drawn. Cards can be put into a player’s hand by other effects as well. At the beginning of the game, each player draws five cards.
        /// </summary>
        public IHand Hand { get; private set; } = new Hand();

        public Guid Id { get; set; }

        /// <summary>
        /// The mana zone is where cards are put in order to produce mana for using other cards. All cards are put into the mana zone upside down. However, multicolored cards are put into the mana zone tapped.
        /// </summary>
        public IManaZone ManaZone { get; private set; } = new ManaZone();

        public string Name { get; set; }

        /// <summary>
        /// At the beginning of the game, each player puts five shields into their shield zone. Castles are put into the shield zone to fortify a shield.
        /// </summary>
        public IShieldZone ShieldZone { get; private set; } = new ShieldZone();

        public IEnumerable<IZone> Zones => new List<IZone> { Deck, Graveyard, Hand, ManaZone, ShieldZone };

        public IPlayer Opponent { get; set; }
        public IGame Game { get; }

        public void ArrangeTopCardsOfDeck(params ICard[] cards)
        {
            var arranged = Choose(new ArrangeChoice(this, cards)).Rearranged;
            Deck.Cards.RemoveAll(x => arranged.Contains(x));
            arranged.ToList().ForEach(x => Deck.Cards.Add(x));
        }

        public void BurnOwnMana(IAbility ability)
        {
            var card = ChooseOwnMana(ability);
            Game.Move(ability, ZoneType.ManaZone, ZoneType.Graveyard, card);
        }

        public bool CanChoose(ICard card)
        {
            return Game.ContinuousEffects.CanPlayerChooseCreature(this, card);
        }

        public void Cast(ICard spell)
        {
            Game.ProcessEvents(new SpellCastEvent(this, spell));
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

        public bool ChooseAttacker(IEnumerable<ICard> attackers)
        {
            int minimum = attackers.Any(Game.ContinuousEffects.DoesCreatureAttackIfAble) ? 1 : 0;
            IEnumerable<ICard> decision = ChooseCards(attackers, minimum, 1, "You may choose a creature to attack with.");
            return decision.Any() && ChooseAttackTarget(attackers.Single(x => x.Id == decision.Single().Id));
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

        public bool ChooseCardToUse(IEnumerable<ICard> usableCards)
        {
            var toUse = ChooseCardOptionally(usableCards, "You may use a card from your hand.");
            if (toUse != null)
            {
                var manaCombinations = toUse.GetManaCombinations(this);
                if (manaCombinations.Count() > 1)
                {
                    ChooseCardsToPayManaCost(toUse);
                }
                else
                {
                    PayManaCostAndUseCard(manaCombinations.Single(), toUse);
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

        public ICard ChooseControlledCreature(string description)
        {
            return ChooseCard(Game.BattleZone.GetCreatures(this), description);
        }

        public ICard ChooseControlledCreatureOptionally(string description, Civilization civilization)
        {
            return ChooseCards(Game.BattleZone.GetCreatures(this, civilization), 0, 1, description).SingleOrDefault();
        }

        public ICard ChooseControlledCreatureOptionally(string description)
        {
            return ChooseCards(Game.BattleZone.GetCreatures(this), 0, 1, description).SingleOrDefault();
        }

        public IEnumerable<ICard> ChooseControlledCreatures(string description, int amount)
        {
            return ChooseCards(Game.BattleZone.GetCreatures(this), amount, amount, description);
        }

        public IEnumerable<ICard> ChooseControlledCreaturesOptionally(int max, string description)
        {
            return ChooseCards(Game.BattleZone.GetCreatures(this), 0, max, description);
        }

        public int ChooseNumber(NumberChoice choice)
        {
            return Choose(choice).Choice.Value;
        }

        public ICard ChooseOpponentsCreature(string description)
        {
            return ChooseCard(Game.BattleZone.GetChoosableCreaturesControlledByChoosersOpponent(this), description);
        }

        public ICard ChooseOpponentsNonEvolutionCreature(string description)
        {
            return ChooseCard(Game.BattleZone.GetChoosableCreaturesControlledByChoosersOpponent(this).Where(x => x.IsNonEvolutionCreature), description);
        }

        public IPlayer ChoosePlayer(string description)
        {
            return Choose(new PlayerChoice(this, description, Game.Players)).Choice;
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

        public ICard DestroyCreatureOptionally(IAbility ability)
        {
            var card = ChooseCardOptionally(Game.BattleZone.GetChoosableCreaturesControlledByAnyone(this), ability.ToString());
            Game.Destroy(ability, card);
            return card;
        }

        public ICard DestroyOpponentsCreatureWithMaxPower(int power, string description)
        {
            return ChooseCard(Game.BattleZone.GetChoosableCreaturesControlledByChoosersOpponent(this).Where(x => x.Power <= power), description);
        }

        public void Discard(IAbility ability, params ICard[] cards)
        {
            _ = Game.Move(ability, ZoneType.Hand, ZoneType.Graveyard, cards);
        }

        public int DiscardAnyNumberOfCards(IAbility ability)
        {
            var cards = ChooseAnyNumberOfCards(Hand.Cards, ability.ToString()).ToArray();
            Discard(ability, cards);
            return cards.Length;
        }

        public void DiscardAtRandom(int amount, IAbility ability)
        {
            if (Hand.HasCards)
            {
                _ = Game.Move(ability, ZoneType.Hand, ZoneType.Graveyard, Hand.Cards.OrderBy(x => Guid.NewGuid()).Take(amount).ToArray());
            }
        }

        public void DiscardOwnCard(IAbility ability)
        {
            var card = ChooseOwnHandCard(ability);
            Game.Move(ability, ZoneType.Hand, ZoneType.Graveyard, card);
        }

        public void DiscardOwnCards(IAbility ability, int amount)
        {
            Discard(ability, ChooseOwnHandCards(amount, ability.ToString()).ToArray());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void DrawCards(int amount, IAbility ability)
        {
            // 121.2. Cards may only be drawn one at a time.
            // If a player is instructed to draw multiple cards,
            // that player performs that many individual card draws.
            for (int i = 0; i < amount; ++i)
            {
                if (Deck.HasCards)
                {
                    Game.ProcessEvents(new DrawCardEvent(this, Deck.Cards.Last(), ability));
                }
            }
        }

        public void DrawCardsOptionally(IAbility source, int maximum)
        {
            for (int i = 0; i < maximum; ++i)
            {
                if (ChooseToTakeAction("You may draw a card."))
                {
                    DrawCards(1, source);
                }
                else
                {
                    break;
                }
            }
        }

        public IEnumerable<ICard> GetCardsThatCanBePaidAndUsed()
        {
            return GetCardsThatCanBePaid().Where(x => Game.CanBeUsedRegardlessOfManaCost(x));
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

        public void Look(IPlayer owner, params ICard[] cards)
        {
            // 701.16d Some effects instruct a player to look at one or more cards.
            // Looking at a card follows the same rules as revealing a card,
            // except that the card is shown only to the specified player.
            owner.Reveal(new List<IPlayer> { this }, cards);
        }

        public void LookAtOneOfOpponentsShields(IAbility source)
        {
            var cards = Opponent.ShieldZone.Cards.ToArray();
            if (cards.Any())
            {
                Look(Opponent, cards);
                Opponent.Unreveal(cards);
            }
        }

        public void LookAtOpponentsHand()
        {
            var cards = Opponent.Hand.Cards.ToArray();
            if (cards.Any())
            {
                Look(Opponent, cards);
                Opponent.Unreveal(cards);
            }
        }

        public IEnumerable<ICard> LookAtTheTopCardsOfYourDeck(int amount)
        {
            var cards = Deck.GetTopCards(amount).ToArray();
            Look(this, cards);
            return cards;
        }

        public void PutFromTopOfDeckIntoManaZone(int amount, IAbility ability)
        {
            for (int i = 0; i < amount; ++i)
            {
                if (Deck.HasCards)
                {
                    Game.Move(ability, ZoneType.Deck, ZoneType.ManaZone, Deck.Cards.Last());
                }
            }
        }

        public void PutFromTopOfDeckIntoShieldZone(int amount, IAbility ability)
        {
            for (int i = 0; i < amount; ++i)
            {
                if (Deck.HasCards)
                {
                    Game.Move(ability, ZoneType.Deck, ZoneType.ShieldZone, Deck.Cards.Last());
                }
            }
        }

        public void PutOnTheBottomOfDeckInAnyOrder(ICard[] cards)
        {
            var arranged = Choose(new ArrangeChoice(this, cards)).Rearranged;
            Deck.Cards.RemoveAll(x => arranged.Contains(x));
            Deck.PutOnBottom(arranged);
        }

        public void PutOwnHandCardIntoMana(IAbility source)
        {
            Game.Move(source, ZoneType.Hand, ZoneType.ManaZone, ChooseCard(Hand.Cards, source.ToString()));
        }

        public void ReturnOwnMana(IAbility source)
        {
            Game.Move(source, ZoneType.ManaZone, ZoneType.Hand, ChooseCard(ManaZone.Cards, source.ToString()));
        }

        public void ReturnOwnManaCards(IAbility source, int amount)
        {
            Game.Move(source, ZoneType.ManaZone, ZoneType.Hand, ChooseCards(ManaZone.Cards, amount, amount, source.ToString()).ToArray());
        }

        public void ReturnOwnManaCreature(IAbility source)
        {
            Game.Move(source, ZoneType.ManaZone, ZoneType.Hand, ChooseCard(ManaZone.Creatures, source.ToString()));
        }

        /// <summary>
        /// 701.16a To reveal a card, show that card to all players for a brief time.
        /// If an effect causes a card to be revealed, it remains revealed for as long
        /// as necessary to complete the parts of the effect that card is relevant to.
        /// </summary>
        /// <param name="cards"></param>
        /// 
        public void ShowCardsToOpponent(params ICard[] cards)
        {
            Reveal(Game.Players, cards);
        }

        public void Reveal(IEnumerable<IPlayer> players, params ICard[] cards)
        {
            // TODO: Implement reveal information on cards and add them here.
            cards.ToList().ForEach(x => x.KnownTo.AddRange(players.Select(x => x.Id)));
            //TODO: Event
            //game.Process(new RevealEvent { Revealer = Copy(), Cards = cards.Select(x => x.Convert()).ToList(), RevealedTo = players.Select(x => x.Copy()).ToList() });
        }

        public void RevealFromTopDeckUntilNonEvolutionCreaturePutIntoBattleZoneRestIntoGraveyard(IAbility source)
        {
            var index = Deck.Cards.FindLastIndex(x => x.IsNonEvolutionCreature);
            var revealed = Deck.Cards.Skip(index).ToArray();
            ShowCardsToOpponent(revealed);
            var creature = index != -1 ? revealed.FirstOrDefault() : null;
            var toGraveyard = revealed.Where(x => x != creature).ToArray();
            if (creature != null)
            {
                Game.Move(source, ZoneType.Deck, ZoneType.BattleZone, creature);
            }
            Game.Move(source, ZoneType.Deck, ZoneType.Graveyard, toGraveyard);
        }

        public IEnumerable<ICard> RevealTopCardsOfDeck(int amount)
        {
            var cards = Deck.GetTopCards(amount);
            ShowCardsToOpponent(cards.ToArray());
            return cards;
        }

        public void Sacrifice(IAbility ability)
        {
            var creature = ChooseControlledCreature(ability.ToString());
            Game.Destroy(ability, creature);
        }

        public void ShuffleOwnDeck()
        {
            Game.ProcessEvents(new ShuffleDeckEvent(this));
        }

        public void Tap(params ICard[] cards)
        {
            var untappedCards = cards.Where(card => card != null && !card.Tapped && Game.ContinuousEffects.CanPlayerTapCreature(this, card)).ToList();
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

        public void TapOpponentsCreature()
        {
            Tap(ChooseOpponentsCreature("Tap one of your opponent's creatures."));
        }

        public override string ToString()
        {
            return Name;
        }

        public void Unreveal(params ICard[] cards)
        {
            // TODO: Implement reveal information on cards and remove them here.
        }

        public void Untap(params ICard[] cards)
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

        public void UseCard(ICard card)
        {
            Game.CurrentTurn.CurrentPhase.UsedCards.Add(card.Copy());
            if (card.IsCreature)
            {
                if (card.Supertypes.Contains(Supertype.Evolution))
                {
                    Evolve(card);
                }
                Summon(card);
            }
            else if (card.IsSpell)
            {
                Cast(card);
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

        private bool ChooseAttackTarget(ICard attacker)
        {
            IEnumerable<IAttackable> possibleTargets = Game.GetPossibleAttackTargets(attacker);
            IAttackable target = possibleTargets.Count() > 1
                ? ChooseAttackTarget(possibleTargets)
                : possibleTargets.Single();
            Tap(attacker);
            if (target is ICard card && card.Id == attacker.Id)
            {
                Game.AddPendingAbilities(attacker.GetTapAbilities().Select(x => x.Copy()).Cast<IResolvableAbility>().ToArray());
                return true;
            }
            else
            {
                Game.ProcessCreatureAttackedEvent(attacker, target);
                return false;
            }
        }

        private void ChooseCardsToPayManaCost(ICard toUse)
        {
            var manaDecision = ChooseCards(ManaZone.UntappedCards, toUse.ManaCost, toUse.ManaCost, "Choose cards to pay the mana cost with.");
            if (Card.HasCivilizations(manaDecision, toUse.Civilizations))
            {
                PayManaCostAndUseCard(manaDecision, toUse);
            }
            else
            {
                ChooseCardsToPayManaCost(toUse);
            }
        }

        private ICard ChooseOwnHandCard(IAbility ability)
        {
            return ChooseCard(Hand.Cards, ability.ToString());
        }

        private IEnumerable<ICard> ChooseOwnHandCards(int amount, string description)
        {
            return ChooseCards(Hand.Cards, amount, amount, description);
        }

        private ICard ChooseOwnMana(IAbility ability)
        {
            return ChooseCard(ManaZone.Cards, ability.ToString());
        }

        /// <summary>
        /// 104.3a A player can concede the game at any time.
        /// A player who concedes leaves the game immediately.
        /// That player loses the game.
        /// </summary>
        /// <param name="game"></param>
        private void Concede()
        {
            //TODO: event
            //game.Process(new ConcedeEvent { Player = Convert() });
            Game.Lose(this);
        }

        private void Evolve(ICard evolutionCreature)
        {
            var effect = evolutionCreature.GetAbilities<IStaticAbility>().Select(x => x.ContinuousEffects).OfType<IEvolutionEffect>().Single();
            effect.Evolve(evolutionCreature);
        }

        private void PayManaCostAndUseCard(IEnumerable<ICard> manaCards, ICard toUse)
        {
            Tap(manaCards.ToArray());
            UseCard(toUse);
        }

        private void Summon(ICard card)
        {
            Game.ProcessEvents(new CreatureSummonedEvent(this, card));
        }

        public IEnumerable<ICard> ChooseWhichCreaturesToKeepTappedToUseTheirSilentSkillAbilities(IEnumerable<ICard> creaturesWithSilentSkill)
        {
            return ChooseAnyNumberOfCards(creaturesWithSilentSkill, "Choose which creatures you want to keep tapped to use their Silent skill abilities. Unchosen creatures will untap instead.");
        }

        public void SearchOwnDeck()
        {
            //TODO: Reveal deck cards to owner
        }

        public void PutCardsFromOwnDeckIntoOwnHand(IAbility ability, ICard[] creatures)
        {
            Game.Move(ability, ZoneType.Deck, ZoneType.Hand, creatures);
        }

        public void TakeCreaturesFromOwnDeckShowThemToOpponentAndPutThemIntoOwnHand(int minimum, int maximum, string description, IAbility ability)
        {
            ICard[] creatures = ChooseCards(Deck.Creatures, minimum, maximum, description).ToArray();
            ShowCardsToOpponent(creatures);
            PutCardsFromOwnDeckIntoOwnHand(ability, creatures);
        }

        public void PutCreatureFromOwnManaZoneIntoBattleZone(ICard mana, IAbility ability)
        {
            Game.Move(ability, ZoneType.ManaZone, ZoneType.BattleZone, mana);
        }

        public void PutCreatureFromBattleZoneIntoItsOwnersManaZone(ICard creature, IAbility ability)
        {
            Game.Move(ability, ZoneType.BattleZone, ZoneType.ManaZone, creature);
        }

        public ICard ChooseCreatureInBattleZoneOptionally(string description)
        {
            return ChooseCardOptionally(Game.BattleZone.GetChoosableCreaturesControlledByAnyone(this), description);
        }

        public void DestroyAllCreaturesThatHaveMaximumPower(int power, IAbility ability)
        {
            Game.Destroy(ability, Game.BattleZone.Creatures.Where(x => x.Power <= power).ToArray());
        }

        public void DiscardAllCreaturesThatHaveMaximumPower(int power, IAbility ability)
        {
            Discard(ability, Hand.Creatures.Where(x => x.Power.HasValue && x.Power <= power).ToArray());
        }

        public ICard DestroyOwnCreatureOptionally(string description, IAbility ability)
        {
            ICard creature = ChooseControlledCreatureOptionally(description);
            Game.Destroy(ability, creature);
            return creature;
        }

        public void PutCreatureFromOwnHandIntoBattleZone(ICard card, IAbility ability) => Game.Move(ability, ZoneType.Hand, ZoneType.BattleZone, card);

        public ICard RevealTopCardOfOwnDeck() => RevealTopCardsOfDeck(1).SingleOrDefault();

        public void PutTopCardOfOwnDeckIntoOwnHand(IAbility ability) => Game.Move(ability, ZoneType.Deck, ZoneType.Hand, Deck.TopCard);

        public void PutTopCardOfOwnDeckIntoOwnGraveyard(IAbility ability) => Game.Move(ability, ZoneType.Deck, ZoneType.Graveyard, Deck.TopCard);
    }
}