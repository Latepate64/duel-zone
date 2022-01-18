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

        internal Queue<GameEvent> PreGameEvents = new Queue<GameEvent>();

        #region Methods
        public Duel() { }

        public Duel(Duel duel)
        {
            DelayedTriggeredAbilities = duel.DelayedTriggeredAbilities.Select(x => new DelayedTriggeredAbility(x)).ToList();
            ExtraTurns = new Queue<Turn>(duel.ExtraTurns.Select(x => new Turn(x)));
            InitialNumberOfHandCards = duel.InitialNumberOfHandCards;
            InitialNumberOfShields = duel.InitialNumberOfShields;
            Losers = duel.Losers.Select(x => x.Copy()).ToList();
            Players = duel.Players.Select(x => x.Copy()).ToList();
            if (duel.Winner != null)
            {
                Winner = duel.Winner.Copy();
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

        public void Play(Player startingPlayer, Player otherPlayer)
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

            var activePlayer = startingPlayer;
            var nonActivePlayer = otherPlayer;
            while (Players.Count > 1)
            {
                StartNewTurn(activePlayer.Id, nonActivePlayer.Id);
                var tmp1 = activePlayer;
                var tmp2 = nonActivePlayer;
                activePlayer = tmp2;
                nonActivePlayer = tmp1;
            }
        }

        private void StartNewTurn(Guid activePlayer, Guid nonActivePlayer)
        {
            if (ExtraTurns.Any())
            {
                Turns.Add(ExtraTurns.Dequeue());
            }
            else
            {
                Turns.Add(new Turn { ActivePlayer = activePlayer, NonActivePlayer = nonActivePlayer });
            }
            Turns.Last().Play(this, Turns.Count);
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
                Destroy(new List<Card> { attackingCreature, defendingCreature });
            }

            void Outcome(Card winner, Card loser)
            {
                Trigger(new WinBattleEvent(winner));
                var destroyed = new List<Card> { loser };
                if (GetContinuousEffects<SlayerEffect>(loser).Any())
                {
                    destroyed.Add(winner);
                }
                Destroy(destroyed);
            }
        }

        public void UseCard(Card card, Player player)
        {
            CurrentTurn.CurrentStep.UsedCards.Add(card.Copy());
            if (card.CardType == CardType.Creature)
            {
                player.Summon(card, this);
            }
            else if (card.CardType == CardType.Spell)
            {
                player.Cast(card, this);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public IEnumerable<Card> GetAllCards()
        {
            return Players.SelectMany(x => x.AllCards).ToList();
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

        public void Destroy(IEnumerable<Card> permanents)
        {
            Move(permanents, ZoneType.BattleZone, ZoneType.Graveyard);
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
            CurrentTurn.CurrentStep.GameEvents.Enqueue(new LoseEvent(player.Copy()));
        }

        public void Win(Player player)
        {
            Winner = player;
            CurrentTurn.CurrentStep.GameEvents.Enqueue(new WinEvent(player.Copy()));
        }

        /// <summary>
        /// Only use this method if exactly one card moves between zones, otherwise use the overload that takes multiple cards.
        /// </summary>
        /// <param name="card"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public void Move(Card card, ZoneType source, ZoneType destination)
        {
            Move(new List<Card> { card }, source, destination);
        }

        /// <summary>
        /// Moving a card into the battle zone may require a choice to be made (eg. Petrova)
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// 
        /// <returns></returns>
        public void Move(IEnumerable<Card> cards, ZoneType source, ZoneType destination)
        {
            Move(cards.Select(x => new CardMovedEvent(x.Owner, x.Id, source, destination)).ToList());
        }

        private void Move(List<CardMovedEvent> events)
        {
            // TODO: Sort players by turn order
            var effects = GetReplacementEffects(events);
            var affectedCardGroups = effects.Select(x => x.EventToReplace).Cast<CardMovedEvent>().Select(x => x.Card).GroupBy(x => GetCard(x).Owner);
            foreach (var cardGroup in affectedCardGroups)
            {
                var effectGroups = effects.Where(x => cardGroup.Contains((x.EventToReplace as CardMovedEvent).Card));
                var player = GetPlayer(cardGroup.Key);
                var effectGuid = effectGroups.Count() > 1
                    ? player.Choose(new GuidSelection(player.Id, effects.Select(x => x.Id), 1, 1)).Decision.Single()
                    : effectGroups.Select(x => x.Id).Single();
                var effect = effectGroups.Single(x => x.Id == effectGuid);
                var newEvent = effect.Apply(this);
                if (newEvent != null)
                {
                    events = events.Where(x => x.Id != effect.EventToReplace.Id).ToList();
                    events.Add(newEvent as CardMovedEvent);
                }
            }
            foreach (var e in events)
            {
                e.Apply(this);
                Trigger(e);
            }
        }

        private List<ReplacementEffect> GetReplacementEffects(IEnumerable<CardMovedEvent> events)
        {
            var replacementEffects = new List<ReplacementEffect>();
            foreach (var moveEvent in events)
            {
                foreach (var replacementEffect in GetAllCards().SelectMany(x => GetContinuousEffects<ReplacementEffect>(x)).Where(x => x.Replaceable(moveEvent, this)))
                {
                    var effect = replacementEffect.Copy() as ReplacementEffect;
                    effect.EventToReplace = moveEvent.Copy();
                    replacementEffects.Add(effect);
                }
            }
            return replacementEffects;
        }

        public void Discard(IEnumerable<Card> cards)
        {
            Move(cards, ZoneType.Hand, ZoneType.Graveyard);
        }

        public void PutFromShieldZoneToHand(Card card, bool canUseShieldTrigger)
        {
            PutFromShieldZoneToHand(new List<Card> { card }, canUseShieldTrigger);
        }

        public void PutFromShieldZoneToHand(IEnumerable<Card> cards, bool canUseShieldTrigger)
        {
            Move(cards, ZoneType.ShieldZone, ZoneType.Hand);
            if (canUseShieldTrigger)
            {
                foreach (var card in cards.Where(x => x.ShieldTrigger))
                {
                    card.ShieldTriggerPending = true;
                }
            }
        }
        #endregion Methods
    }
}
