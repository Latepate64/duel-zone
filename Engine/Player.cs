using Common;
using Engine.Abilities;
using Common.Choices;
using Engine.ContinuousEffects;
using Engine.Zones;
using System;
using System.Collections.Generic;
using System.Linq;
using Engine.Steps;
using Engine.GameEvents;

namespace Engine
{
    /// <summary>
    /// 102.1. A player is one of the people in the game.
    /// </summary>
    public abstract class Player : Common.Player, IDisposable, IPlayer
    {
        #region Properties
        /// <summary>
        /// When a game begins, each player’s deck becomes their deck.
        /// </summary>
        public IDeck Deck { get; private set; } = new Deck();

        /// <summary>
        /// A player’s graveyard is their discard pile. Discarded cards, destroyed creatures and spells cast are put in their owner's graveyard.
        /// </summary>
        public Graveyard Graveyard { get; private set; } = new();

        /// <summary>
        /// The hand is where a player holds cards that have been drawn. Cards can be put into a player’s hand by other effects as well. At the beginning of the game, each player draws five cards.
        /// </summary>
        public Hand Hand { get; private set; } = new();

        /// <summary>
        /// The mana zone is where cards are put in order to produce mana for using other cards. All cards are put into the mana zone upside down. However, multicolored cards are put into the mana zone tapped.
        /// </summary>
        public IManaZone ManaZone { get; private set; } = new ManaZone();

        /// <summary>
        /// At the beginning of the game, each player puts five shields into their shield zone. Castles are put into the shield zone to fortify a shield.
        /// </summary>
        public ShieldZone ShieldZone { get; private set; } = new();

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

        public IEnumerable<IZone> Zones => new List<IZone> { Deck, Graveyard, Hand, ManaZone, ShieldZone };

        public Guid AttackableId { get; set; }

        public bool DirectlyAttacked { get; set; }
        #endregion Properties

        private static readonly Random Random = new();

        #region Methods
        protected Player()
        {
        }

        protected Player(IPlayer player) : base(player)
        {
            Deck = new Deck(player.Deck);
            Graveyard = new Graveyard(player.Graveyard);
            Hand = new Hand(player.Hand);
            ManaZone = new ManaZone(player.ManaZone);
            ShieldZone = new ShieldZone(player.ShieldZone);
        }

        public override string ToString()
        {
            return Name;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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

        public YesNoDecision Choose(YesNoChoice yesNoChoice, IGame game)
        {
            var decision = ClientChoose(yesNoChoice);
            if (decision != null)
            {
                return decision;
            }
            else
            {
                Concede(game);
                return new YesNoDecision();
            }
        }

        public abstract YesNoDecision ClientChoose(YesNoChoice yesNoChoice);

        public IGuidDecision Choose(GuidSelection selection, IGame game)
        {
            var legal = false;
            IGuidDecision decision = null;
            while (!legal)
            {
                decision = ClientChoose(selection);
                if (decision != null)
                {
                    var dist = decision.Decision.Distinct();
                    legal = selection.IsLegal(dist);
                }
                else
                {
                    Concede(game);
                    return new GuidDecision();
                }
            }
            return decision;
        }

        public abstract IGuidDecision ClientChoose(GuidSelection guidSelection);

        public void ShuffleDeck(IGame game)
        {
            game.Process(new ShuffleDeckEvent(this));
        }

        public void PutFromTopOfDeckIntoShieldZone(int amount, IGame game)
        {
            for (int i = 0; i < amount; ++i)
            {
                if (Deck.Cards.Any())
                {
                    game.Move(ZoneType.Deck, ZoneType.ShieldZone, Deck.Cards.Last());
                }
            }
        }

        private void Summon(ICard card, IGame game)
        {
            throw new System.NotImplementedException();
            //game.Process(new CreatureSummonedEvent { Player = Copy(), Creature = card.Convert() });
            _ = game.Move(ZoneType.Hand, ZoneType.BattleZone, card);
        }

        public void DrawCards(int amount, IGame game)
        {
            // 121.2. Cards may only be drawn one at a time.
            // If a player is instructed to draw multiple cards,
            // that player performs that many individual card draws.
            for (int i = 0; i < amount; ++i)
            {
                if (Deck.Cards.Any())
                {
                    game.Move(ZoneType.Deck, ZoneType.Hand, Deck.Cards.Last());
                }
            }
        }

        internal IEnumerable<ICard> GetCardsThatCanBePaid()
        {
            return Hand.Cards.Where(card => card.CanBePaid(this));
        }

        public IEnumerable<ICard> GetCardsThatCanBePaidAndUsed(IGame game)
        {
            return GetCardsThatCanBePaid().Where(x => x.CanBeUsedRegardlessOfManaCost(game));
        }

        public void PutFromTopOfDeckIntoManaZone(IGame game, int amount)
        {
            for (int i = 0; i < amount; ++i)
            {
                if (Deck.Cards.Any())
                {
                    game.Move(ZoneType.Deck, ZoneType.ManaZone, Deck.Cards.Last());
                }
            }
        }

        public void Cast(ICard spell, IGame game)
        {
            // 601.2a To propose the casting of a spell, a player first moves that card from where it is to the stack.
            game.GetZone(spell).Remove(spell, game);
            game.SpellsBeingCast.Push(spell);
            game.AddContinuousEffects(spell, spell.GetAbilities<IStaticAbility>().Where(x => x.FunctionZone == ZoneType.Anywhere).ToArray());
            spell.KnownTo = game.Players.Select(x => x.Id).ToList();
            throw new System.NotImplementedException();
            //game.Process(new SpellCastEvent(Convert(), spell.Convert()));
            ResolveSpellAbilities(spell, game);
            FinishCastingSpell(spell, game);
        }

        private static void ResolveSpellAbilities(ICard spell, IGame game)
        {
            foreach (var ability in spell.GetAbilities<SpellAbility>().Select(x => x.Copy()).Cast<SpellAbility>())
            {
                ability.Source = spell.Id;
                ability.Controller = spell.Owner;
                ability.Resolve(game);
            }
        }

        /// <summary>
        /// 608.2m As the final part of a spell’s resolution, the spell is put into its owner’s graveyard.
        /// </summary>
        /// <param name="spell"></param>
        /// <param name="game"></param>
        private void FinishCastingSpell(ICard spell, IGame game)
        {
            // 400.7. An object that moves from one zone to another becomes a new object with no memory of, or relation to, its previous existence.
            var newObject = new Card(spell, game.GetTimestamp());
            ZoneType destination;
            try
            {
                if (game.GetContinuousEffects<IChargerEffect>().Union(spell.GetAbilities<IStaticAbility>().SelectMany(x => x.ContinuousEffects).OfType<IChargerEffect>()).Any(e => e.Applies(spell, game)))
                {
                    game.SpellsBeingCast.Pop();
                    game.RemoveContinuousEffects(spell.GetAbilities<IStaticAbility>().Where(x => x.FunctionZone == ZoneType.Anywhere).Select(x => x.Id));
                    game.GetPlayer(newObject.Owner).ManaZone.Add(newObject, game);
                    destination = ZoneType.ManaZone;
                }
                else
                {
                    game.SpellsBeingCast.Pop();
                    game.RemoveContinuousEffects(spell.GetAbilities<IStaticAbility>().Where(x => x.FunctionZone == ZoneType.Anywhere).Select(x => x.Id));
                    game.GetPlayer(newObject.Owner).Graveyard.Add(newObject, game);
                    destination = ZoneType.Graveyard;
                }
                throw new System.NotImplementedException();
                //game.Process(new CardMovedEvent { Card = newObject.Convert(), CardInSourceZone = spell.Id, Destination = destination, Player = Convert(), Source = ZoneType.Anywhere });
            }
            catch (PlayerNotInGameException)
            {
            }
        }

        public void DiscardAtRandom(IGame game, int amount)
        {
            if (Hand.Cards.Any())
            {
                _ = game.Move(ZoneType.Hand, ZoneType.Graveyard, Hand.Cards.OrderBy(x => Guid.NewGuid()).Take(amount).ToArray());
            }
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
            throw new System.NotImplementedException();
            //game.Process(new RevealEvent { Revealer = Copy(), Cards = cards.Select(x => x.Convert()).ToList(), RevealedTo = players.Select(x => x.Copy()).ToList() });
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

        public Common.IPlayer Copy()
        {
            return Convert();
        }

        private void ChooseCardsToPayManaCost(IGame game, ICard toUse)
        {
            var manaDecision = Choose(new PaymentSelection(Id, ManaZone.UntappedCards, toUse.ManaCost, toUse.ManaCost), game).Decision.Select(x => game.GetCard(x));
            if (Card.HasCivilizations(manaDecision, toUse.Civilizations))
            {
                PayManaCostAndUseCard(game, manaDecision, toUse);
            }
            else
            {
                ChooseCardsToPayManaCost(game, toUse);
            }
        }

        private void PayManaCostAndUseCard(IGame game, IEnumerable<ICard> manaCards, ICard toUse)
        {
            Tap(game, manaCards.ToArray());
            UseCard(toUse, game);
        }

        public bool ChooseCardToUse(IGame game, IEnumerable<ICard> usableCards)
        {
            var decision = Choose(new UseCardSelection(Id, usableCards), game).Decision;
            if (decision.Any())
            {
                var id = decision.Single();
                var toUse = usableCards.Single(x => x.Id == id);
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

        private void Evolve(ICard card, IGame game)
        {
            var baits = game.GetCreaturesCreatureCanEvolveFrom(card);
            var bait = game.GetCard(Choose(new EvolutionBaitSelection(Id, baits), game).Decision.Single());
            card.PutOnTopOf(bait);
        }

        public Common.IPlayer Convert()
        {
            return new Common.Player(this);
        }

        public void Tap(IGame game, params ICard[] cards)
        {
            var untappedCards = cards.Where(x => !x.Tapped).ToList();
            foreach (var card in untappedCards)
            {
                card.Tapped = true;
            }
            if (untappedCards.Any())
            {
                throw new System.NotImplementedException();
                //game.Process(new TapEvent(Convert(), untappedCards.Select(x => x.Convert()).ToList(), true));
            }
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
                throw new System.NotImplementedException();
                //game.Process(new TapEvent(Convert(), tappedCards.Select(x => x.Convert()).ToList(), false));
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
            throw new System.NotImplementedException();
            //game.Process(new ConcedeEvent { Player = Convert() });
            game.Lose(this);
        }

        public void Look(IPlayer owner, IGame game, params ICard[] cards)
        {
            // 701.16d Some effects instruct a player to look at one or more cards.
            // Looking at a card follows the same rules as revealing a card,
            // except that the card is shown only to the specified player.
            owner.Reveal(game, new List<IPlayer> { this }, cards);
        }

        public void ChooseAttacker(IGame game, IEnumerable<ICard> attackers)
        {
            var minimum = attackers.Any(attacker => game.GetContinuousEffects<IAttacksIfAbleEffect>().Any(effect => effect.Applies(attacker, game))) ? 1 : 0;
            var decision = Choose(new AttackerSelection(Id, attackers, minimum), game).Decision;
            if (decision.Any())
            {
                ChooseAttackTarget(game, attackers, decision.Single());
            }
        }

        private void ChooseAttackTarget(IGame game, IEnumerable<ICard> attackers, Guid id)
        {
            var attacker = attackers.Single(x => x.Id == id);
            var possibleTargets = game.GetPossibleAttackTargets(attacker);
            Common.IIdentifiable target = possibleTargets.Count() > 1
                ? game.GetAttackable(Choose(new AttackTargetSelection(Id, possibleTargets.Select(x => x.Id), 1, 1), game).Decision.Single())
                : possibleTargets.Single();
            Tap(game, attacker);
            if (target.Id == attacker.Id)
            {
                game.AddPendingAbilities(attacker.GetAbilities<TapAbility>().Select(x => x.Copy()).Cast<IResolvableAbility>().ToArray());
            }
            else
            {
                var phase = game.CurrentTurn.CurrentPhase as AttackPhase;
                phase.SetAttackingCreature(attacker, game);
                phase.AttackTarget = target.Id;
                throw new System.NotImplementedException();
                //game.Process(new CreatureAttackedEvent { Card = attacker.Convert(), Attackable = game.GetAttackable(phase.AttackTarget).Id });
            }
        }

        public IEnumerable<ICard> RevealTopCardsOfDeck(int amount, IGame game)
        {
            var cards = Deck.GetTopCards(amount);
            Reveal(game, cards.ToArray());
            return cards;
        }

        public void Unreveal(IEnumerable<ICard> cards)
        {
            // TODO: Implement reveal information on cards and remove them here.
        }

        public void Discard(IGame game, params ICard[] cards)
        {
            _ = game.Move(ZoneType.Hand, ZoneType.Graveyard, cards);
        }

        public abstract Subtype ChooseRace(params Subtype[] excluded);
        public abstract int ChooseNumber(string text, int minimum, int? maximum);
        #endregion Methods
    }
}