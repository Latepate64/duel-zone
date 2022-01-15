using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;
using DuelMastersModels.GameEvents;
using DuelMastersModels.Zones;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels
{
    public class Duel : IDisposable
    {
        #region Properties
        /// <summary>
        /// Players who are still in the game.
        /// </summary>
        public ICollection<Player> Players { get; } = new Collection<Player>();

        public Player Winner { get; private set; }

        public ICollection<Player> Losers { get; } = new Collection<Player>();

        /// <summary>
        /// The number of shields each player has at the start of a duel. 
        /// </summary>
        public int InitialNumberOfShields { get; set; } = 5;

        /// <summary>
        /// The number of cards each player draw at the start of a duel.
        /// </summary>
        public int InitialNumberOfHandCards { get; set; } = 5;

        public Turn CurrentTurn => Turns.Last();

        public IEnumerable<GameEvent> GameEvents => PreGameEvents.Union(Turns.SelectMany(x => x.Steps).SelectMany(x => x.GameEvents));

        public string GameEventsText => string.Join(Environment.NewLine, GameEvents.Select(x => x.ToString(this)));

        /// <summary>
        /// Note: Use method GetChoosableCreaturePermanents if you have to select creature/s.
        /// </summary>
        public IEnumerable<Card> CreaturePermanents => Players.SelectMany(x => x.BattleZone.Creatures);

        /// <summary>
        /// All the turns of the duel that have been or are processed, in order.
        /// </summary>
        public IList<Turn> Turns { get; } = new List<Turn>();

        public List<ContinuousEffect> ContinuousEffects { get; } = new List<ContinuousEffect>();

        public Queue<Turn> ExtraTurns { get; private set; } = new Queue<Turn>();

        public List<DelayedTriggeredAbility> DelayedTriggeredAbilities { get; } = new List<DelayedTriggeredAbility>();
        #endregion Properties

        #region Fields
        internal Stack<Card> ResolvingSpells = new Stack<Card>();
        internal Queue<SpellAbility> ResolvingSpellAbilities = new Queue<SpellAbility>();
        internal Queue<GameEvent> PreGameEvents = new Queue<GameEvent>();
        #endregion Fields

        #region Methods
        public Duel() { }

        public Duel(Duel duel)
        {
            DelayedTriggeredAbilities = duel.DelayedTriggeredAbilities.Select(x => new DelayedTriggeredAbility(x)).ToList();
            ExtraTurns = new Queue<Turn>(duel.ExtraTurns.Select(x => new Turn(x)));
            InitialNumberOfHandCards = duel.InitialNumberOfHandCards;
            InitialNumberOfShields = duel.InitialNumberOfShields;
            Losers = duel.Losers.Select(x => new Player(x)).ToList();
            Players = duel.Players.Select(x => new Player(x)).ToList();
            ResolvingSpellAbilities = new Queue<SpellAbility>(duel.ResolvingSpellAbilities.Select(x => x.Copy()).Cast<SpellAbility>());
            ResolvingSpells = new Stack<Card>(duel.ResolvingSpells.Select(x => x.Copy()));
            if (duel.Winner != null)
            {
                Winner = new Player(duel.Winner);
            }
            Turns = duel.Turns.Select(x => new Turn(x)).ToList();
            ContinuousEffects = duel.ContinuousEffects.Select(x => x.Copy()).ToList();
        }

        public override string ToString()
        {
            return $"{CurrentTurn}";
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
                foreach (var x in ExtraTurns)
                {
                    x.Dispose();
                }
                ExtraTurns = null;
                foreach (var x in Players)
                {
                    x.Dispose();
                }
                Players.Clear();
                foreach (var x in DelayedTriggeredAbilities)
                {
                    x.Dispose();
                }
                DelayedTriggeredAbilities.Clear();
                ResolvingSpellAbilities = null;
                foreach (var x in ResolvingSpells)
                {
                    x.Dispose();
                }
                ResolvingSpells = null;
                foreach (var x in Turns)
                {
                    x.Dispose();
                }
                Turns.Clear();
                foreach (var x in ContinuousEffects)
                {
                    x.Dispose();
                }
                ContinuousEffects.Clear();
            }
        }

        public Choice Start(Player startingPlayer, Player otherPlayer)
        {
            Players.Add(startingPlayer);
            Players.Add(otherPlayer);

            foreach (var card in Players.SelectMany(x => x.AllCards))
            {
                card.InitializeAbilities();
            }

            // 103.2. After the starting player has been determined, each player shuffles their deck so that the cards are in a random order.
            startingPlayer.ShuffleDeck(this);
            otherPlayer.ShuffleDeck(this);

            startingPlayer.PutFromTopOfDeckIntoShieldZone(InitialNumberOfShields, this);
            otherPlayer.PutFromTopOfDeckIntoShieldZone(InitialNumberOfShields, this);

            startingPlayer.DrawCards(InitialNumberOfHandCards, this);
            otherPlayer.DrawCards(InitialNumberOfHandCards, this);

            return StartNewTurn(startingPlayer.Id, otherPlayer.Id);
        }

        private Choice StartNewTurn(Guid activePlayer, Guid nonActivePlayer)
        {
            if (ExtraTurns.Any())
            {
                Turns.Add(ExtraTurns.Dequeue());
            }
            else
            {
                Turns.Add(new Turn { ActivePlayer = activePlayer, NonActivePlayer = nonActivePlayer });
            }
            return Turns.Last().Start(this, Turns.Count);
        }

        public Choice Continue(Decision decision)
        {
            var choiceVar = CurrentTurn.Continue(decision, this);
            if (choiceVar == null && Players.Count > 1)
            {
                return StartNewTurn(CurrentTurn.NonActivePlayer, CurrentTurn.ActivePlayer);
            }
            else
            {
                return choiceVar;
            }
        }

        public void Battle(Guid attackingCreatureId, Guid defendingCreatureId)
        {
            var attackingCreature = GetPermanent(attackingCreatureId);
            var defendingCreature = GetPermanent(defendingCreatureId);
            int attackingCreaturePower = GetPower(attackingCreature);
            int defendingCreaturePower = GetPower(defendingCreature);

            CurrentTurn.CurrentStep.GameEvents.Enqueue(new BattleEvent(attackingCreature, attackingCreaturePower, defendingCreature, defendingCreaturePower));

            //TODO: Handle destruction as a state-based action. 703.4d
            if (attackingCreaturePower > defendingCreaturePower)
            {
                Outcome(attackingCreature, defendingCreature);
            }
            else if (attackingCreaturePower < defendingCreaturePower)
            {
                Outcome(defendingCreature, attackingCreature);
            }
            else
            {
                PutFromBattleZoneIntoGraveyard(attackingCreature);
                PutFromBattleZoneIntoGraveyard(defendingCreature);
            }

            void Outcome(Card winner, Card loser)
            {
                Trigger(new WinBattleEvent(winner));
                PutFromBattleZoneIntoGraveyard(loser);
                if (GetContinuousEffects<SlayerEffect>(loser).Any())
                {
                    PutFromBattleZoneIntoGraveyard(winner);
                }
            }
        }

        public Choice UseCard(Card card, Player player)
        {
            CurrentTurn.CurrentStep.UsedCards.Add(card.Copy());
            if (card.CardType == CardType.Creature)
            {
                return player.Summon(card, this);
            }
            else if (card.CardType == CardType.Spell)
            {
                player.Cast(card, this);
                return null;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public IEnumerable<Card> GetAllCards()
        {
            var cards = Players.SelectMany(x => x.AllCards).ToList();
            cards.AddRange(ResolvingSpells);
            return cards;
        }

        private static List<List<Civilization>> GetCivilizationCombinations(List<List<Civilization>> civilizationGroups, List<Civilization> knownCivilizations)
        {
            if (civilizationGroups.Count > 0)
            {
                List<Civilization> civilizations = civilizationGroups.First();
                List<List<Civilization>> newCivilizationGroups = new List<List<Civilization>>(civilizationGroups);
                _ = newCivilizationGroups.Remove(civilizations);
                List<List<Civilization>> output = new List<List<Civilization>>();
                foreach (Civilization civilization in civilizations)
                {
                    List<Civilization> newKnownCivilizations = new List<Civilization>(knownCivilizations) { civilization };

                    output.AddRange(
                        GetCivilizationCombinations(
                            newCivilizationGroups,
                            newKnownCivilizations));
                }
                return output;
            }
            else
            {
                List<Civilization> copyOfKnownCivilizations = new List<Civilization>(knownCivilizations);
                return new List<List<Civilization>> { copyOfKnownCivilizations };
            }
        }

        public void Destroy(List<Card> permanents)
        {
            for (int i = 0; i < permanents.Count; ++i)
            {
                Destroy(permanents.ElementAt(i));
            }
        }

        public void Destroy(Card permanent)
        {
            PutFromBattleZoneIntoGraveyard(permanent);
        }

        public Player GetOpponent(Player player)
        {
            return Players.Union(Losers).Single(x => x != player);
        }

        public Guid GetOpponent(Guid player)
        {
            return Players.Single(x => x.Id != player).Id;
        }

        public Player GetOwner(Card card)
        {
            return Players.Union(Losers).Single(x => x.Id == card.Owner);
        }

        public Card GetCard(Guid id)
        {
            return GetAllCards().Single(c => c.Id == id);
        }

        public IEnumerable<Card> Permanents => Players.SelectMany(x => x.BattleZone.Cards);

        public Card GetPermanent(Guid id)
        {
            return Permanents.Single(x => x.Id == id);
        }

        public Player GetPlayer(Guid id)
        {
            return Players.Union(Losers).Single(x => x.Id == id);
        }

        /// <summary>
        /// Use this method only if the type of the DuelObject is not certain.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IAttackable GetAttackable(Guid id)
        {
            if (Players.Any(x => x.Id == id))
            {
                return GetPlayer(id);
            }
            else if (Permanents.Any(x => x.Id == id))
            {
                return GetPermanent(id);
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public void Trigger(GameEvent gameEvent)
        {
            CurrentTurn.CurrentStep.GameEvents.Enqueue(gameEvent);
            var abilities = GetAbilitiesThatTriggerFromPermanents(gameEvent).ToList();
            List<DelayedTriggeredAbility> toBeRemoved = new List<DelayedTriggeredAbility>();
            foreach (var ability in DelayedTriggeredAbilities.Where(x => x.TriggeredAbility.CanTrigger(gameEvent, this)))
            {
                abilities.Add(ability.TriggeredAbility.Copy() as TriggeredAbility);
                if (ability.Duration is Once)
                {
                    toBeRemoved.Add(ability);
                }
            }
            _ = DelayedTriggeredAbilities.RemoveAll(x => toBeRemoved.Contains(x));
            CurrentTurn.CurrentStep.PendingAbilities.AddRange(abilities);
            foreach (var ability in abilities)
            {
                CurrentTurn.CurrentStep.GameEvents.Enqueue(new AbilityTriggeredEvent(ability));
            }
        }

        public IEnumerable<TriggeredAbility> GetAbilitiesThatTriggerFromPermanents(GameEvent gameEvent)
        {
            var abilities = new List<TriggeredAbility>();
            foreach (var permanent in Permanents)
            {
                abilities.AddRange(permanent.Abilities.OfType<TriggeredAbility>().Where(x => x.CanTrigger(gameEvent, this)).Select(x => x.Trigger(permanent.Id, permanent.Owner)));
            }
            return abilities;
        }

        public int GetPower(Card card)
        {
            return card.Power.Value + GetContinuousEffects<PowerModifyingEffect>(card).Sum(x => x.GetPower(this));
        }

        public IEnumerable<T> GetContinuousEffects<T>(Card card) where T : ContinuousEffect
        {
            var abilities = Permanents.SelectMany(x => x.Abilities).OfType<StaticAbility>().Where(x => x.FunctionZone == ZoneType.BattleZone).ToList();
            abilities.AddRange(ResolvingSpells.SelectMany(x => x.Abilities).OfType<StaticAbility>().Where(x => x.FunctionZone == ZoneType.SpellStack));
            return abilities.SelectMany(x => x.ContinuousEffects).OfType<T>().Union(ContinuousEffects.OfType<T>()).Where(x => x.Filters.All(f => f.Applies(card, this)));
        }

        public IEnumerable<Card> GetChoosableCreaturePermanents(Player selector)
        {
            var creatures = selector.BattleZone.Creatures.ToList();
            creatures.AddRange(GetOpponent(selector).BattleZone.Creatures.Where(x => !GetContinuousEffects<UnchoosableEffect>(x).Any()));
            return creatures;
        }

        public void Lose(Player player)
        {
            Losers.Add(player);
            _ = Players.Remove(player);
            CurrentTurn.CurrentStep.GameEvents.Enqueue(new LoseEvent(new Player(player)));
        }

        public void Win(Player player)
        {
            Winner = player;
            CurrentTurn.CurrentStep.GameEvents.Enqueue(new WinEvent(new Player(player)));
        }

        /// <summary>
        /// Moving a card into the battle zone may require a choice to be made (eg. Petrova)
        /// </summary>
        /// <param name="card"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// 
        /// <returns></returns>
        public Choice Move(Card card, ZoneType source, ZoneType destination)
        {
            var owner = GetOwner(card);
            var sourceZone = owner.GetZone(source);
            var destinationZone = owner.GetZone(destination);

            sourceZone.Remove(card);

            // 400.7. An object that moves from one zone to another becomes a new object with no memory of, or relation to, its previous existence.
            var newObject = new Card(card, false);
            var choice = destinationZone.Add(newObject, this, sourceZone);
            if (choice == null)
            {
                Trigger(new CardMovedEvent(owner, newObject, sourceZone, destinationZone));
                return null;
            }
            else
            {
                return choice;
            }
        }

        public void Discard(List<Card> cards)
        {
            for (int i = 0; i < cards.Count; ++i)
            {
                Discard(cards.ElementAt(i));
            }
        }

        public void Discard(Card card)
        {
            _ = Move(card, ZoneType.Hand, ZoneType.Graveyard);
        }

        public void PutFromBattleZoneIntoGraveyard(Card permanent)
        {
            _ = Move(permanent, ZoneType.BattleZone, ZoneType.Graveyard);
        }

        public Choice PutFromManaZoneIntoBattleZone(Card card)
        {
            return Move(card, ZoneType.ManaZone, ZoneType.BattleZone);
        }

        public void PutFromShieldZoneToHand(Card card, bool canUseShieldTrigger)
        {
            PutFromShieldZoneToHand(new List<Card> { card }, canUseShieldTrigger);
        }

        public void PutFromShieldZoneToHand(IEnumerable<Card> cards, bool canUseShieldTrigger)
        {
            for (int i = 0; i < cards.Count(); ++i)
            {
                var card = cards.ElementAt(i);
                _ = Move(card, ZoneType.ShieldZone, ZoneType.Hand);
                if (canUseShieldTrigger && card.ShieldTrigger)
                {
                    card.ShieldTriggerPending = true;
                }
            }
        }
        #endregion Methods
    }
}
