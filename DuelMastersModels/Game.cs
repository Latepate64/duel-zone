﻿using DuelMastersModels.Abilities;
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
    public class Game : IDisposable
    {
        #region Properties
        /// <summary>
        /// Players who are still in the game.
        /// </summary>
        public ICollection<Player> Players { get; } = new Collection<Player>();

        public Player Winner { get; private set; }

        public ICollection<Player> Losers { get; } = new Collection<Player>();

        /// <summary>
        /// The number of shields each player has at the start of a game. 
        /// </summary>
        public int StartingNumberOfShields { get; set; } = 5;

        /// <summary>
        /// The number of cards each player draw at the start of a game.
        /// </summary>
        public int StartingHandSize { get; set; } = 5;

        public Turn CurrentTurn => Turns.Last();

        public IEnumerable<GameEvent> GameEvents => PreGameEvents.Union(Turns.SelectMany(x => x.Steps).SelectMany(x => x.GameEvents));

        public string GameEventsText => string.Join(Environment.NewLine, GameEvents.Select(x => x.ToString(this)));

        /// <summary>
        /// All the turns of the game that have been or are processed, in order.
        /// </summary>
        public IList<Turn> Turns { get; } = new List<Turn>();

        /// <summary>
        /// 611.2a A continuous effect generated by the resolution of a spell or ability lasts as long as stated by the spell or ability creating it (such as “until end of turn”).
        /// If no duration is stated, it lasts until the end of the game.
        /// </summary>
        public List<ContinuousEffect> ContinuousEffects { get; } = new List<ContinuousEffect>();

        /// <summary>
        /// 500.7. Some effects can give a player extra turns.
        /// They do this by adding the turns directly after the specified turn.
        /// If a player is given multiple extra turns, the extra turns are added one at a time.
        /// If multiple players are given extra turns, the extra turns are added one at a time, in APNAP order (see rule 101.4).
        /// The most recently created turn will be taken first.
        /// </summary>
        public Stack<Turn> ExtraTurns { get; private set; } = new Stack<Turn>();

        /// <summary>
        /// 603.7. An effect may create a delayed triggered ability that can do something at a later time.
        /// A delayed triggered ability will contain “when,” “whenever,” or “at,” although that word won’t usually begin the ability.
        /// </summary>
        public List<DelayedTriggeredAbility> DelayedTriggeredAbilities { get; } = new List<DelayedTriggeredAbility>();
        #endregion Properties

        internal Queue<GameEvent> PreGameEvents = new Queue<GameEvent>();

        /// <summary>
        /// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
        /// </summary>
        public BattleZone BattleZone { get; set; } = new BattleZone(new List<Card>());

        #region Methods
        public Game() { }

        public Game(Game game)
        {
            DelayedTriggeredAbilities = game.DelayedTriggeredAbilities.Select(x => new DelayedTriggeredAbility(x)).ToList();
            ExtraTurns = new Stack<Turn>(game.ExtraTurns.Select(x => new Turn(x)));
            StartingHandSize = game.StartingHandSize;
            StartingNumberOfShields = game.StartingNumberOfShields;
            Losers = game.Losers.Select(x => x.Copy()).ToList();
            Players = game.Players.Select(x => x.Copy()).ToList();
            if (game.Winner != null)
            {
                Winner = game.Winner.Copy();
            }
            Turns = game.Turns.Select(x => new Turn(x)).ToList();
            ContinuousEffects = game.ContinuousEffects.Select(x => x.Copy()).ToList();
            BattleZone = game.BattleZone.Copy() as BattleZone;
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
                BattleZone?.Dispose();
                BattleZone = null;
            }
        }

        public void Play(Player startingPlayer, Player otherPlayer)
        {
            // 103.1. At the start of a game, the players determine which one of them will choose who takes the first turn. In the first game of a match (including a single - game match), the players may use any mutually agreeable method (flipping a coin, rolling dice, etc.) to do so.In a match of several games, the loser of the previous game chooses who takes the first turn. If the previous game was a draw, the player who made the choice in that game makes the choice in this game.

            // 103.1. The player chosen to take the first turn is the starting player. The game’s default turn order begins with the starting player and proceeds clockwise.
            Players.Add(startingPlayer);
            Players.Add(otherPlayer);

            foreach (var card in GetAllCards())
            {
                card.InitializeAbilities();
            }

            // 103.2. After the starting player has been determined, each player shuffles their deck so that the cards are in a random order.
            Players.ToList().ForEach(x => x.ShuffleDeck(this));

            // Each player puts five card from to the top of their deck into their shield zone.
            Players.ToList().ForEach(x => x.PutFromTopOfDeckIntoShieldZone(StartingNumberOfShields, this));

            // 103.4. Each player draws a number of cards equal to their starting hand size, which is normally five.
            Players.ToList().ForEach(x => x.DrawCards(StartingHandSize, this));

            // 103.7. The starting player takes their first turn.
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
                Turns.Add(ExtraTurns.Pop());
            }
            else
            {
                Turns.Add(new Turn { ActivePlayer = activePlayer, NonActivePlayer = nonActivePlayer });
            }
            Turns.Last().Play(this, Turns.Count);
        }

        public void Battle(Guid attackingCreatureId, Guid defendingCreatureId)
        {
            var attackingCreature = GetCard(attackingCreatureId);
            var defendingCreature = GetCard(defendingCreatureId);
            int attackingCreaturePower = GetPower(attackingCreature);
            int defendingCreaturePower = GetPower(defendingCreature);

            Process(new BattleEvent(attackingCreature, attackingCreaturePower, defendingCreature, defendingCreaturePower));

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
                Process(new WinBattleEvent(winner));
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

        public IEnumerable<Card> GetAllCards(Guid owner)
        {
            return GetAllCards().Where(x => x.Owner == owner);
        }

        public IEnumerable<Card> GetAllCards()
        {
            return Players.SelectMany(x => x.CardsInNonsharedZones).Union(BattleZone.Cards);
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

        public void Destroy(IEnumerable<Card> cards)
        {
            _ = Move(cards, ZoneType.BattleZone, ZoneType.Graveyard);
        }

        /// <summary>
        /// 102.2. In a two-player game, a player’s opponent is the other player.
        /// </summary>
        /// <param name="player"></param>
        /// <returns>Opponent if they are still in the game, null otherwise.</returns>
        public Player GetOpponent(Player player)
        {
            return Players.SingleOrDefault(x => x != player);
        }

        /// <summary>
        /// 102.2. In a two-player game, a player’s opponent is the other player.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public Guid GetOpponent(Guid player)
        {
            return Players.Single(x => x.Id != player).Id;
        }

        /// <summary>
        /// 108.3. The owner of a card in the game is the player who started the game with it in their deck.
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public Player GetOwner(Card card)
        {
            return Players.Union(Losers).Single(x => x.Id == card.Owner);
        }

        public Card GetCard(Guid id)
        {
            return GetAllCards().Single(c => c.Id == id);
        }

        public Card TryGetCard(Guid id)
        {
            return GetAllCards().SingleOrDefault(c => c.Id == id);
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
            else if (BattleZone.Creatures.Any(x => x.Id == id))
            {
                return GetCard(id);
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public void Process(GameEvent gameEvent)
        {
            if (Turns.Any())
            {
                CurrentTurn.CurrentStep.GameEvents.Enqueue(gameEvent);
                foreach (var effect in ContinuousEffects)
                {
                    effect.Update(this, gameEvent);
                }
                var abilities = GetAbilitiesThatTriggerFromCardsInBattleZone(gameEvent).ToList();
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
                    Process(new AbilityTriggeredEvent(ability));
                }
            }
            else
            {
                PreGameEvents.Enqueue(gameEvent);
            }
        }

        public IEnumerable<TriggeredAbility> GetAbilitiesThatTriggerFromCardsInBattleZone(GameEvent gameEvent)
        {
            var abilities = new List<TriggeredAbility>();
            foreach (var card in BattleZone.Cards)
            {
                abilities.AddRange(card.Abilities.OfType<TriggeredAbility>().Where(x => x.CanTrigger(gameEvent, this)).Select(x => x.Trigger(card.Id, card.Owner)));
            }
            return abilities;
        }

        public int GetPower(Card card)
        {
            return card.Power.Value + GetContinuousEffects<PowerModifyingEffect>(card).Sum(x => x.GetPower(this));
        }

        public IEnumerable<T> GetContinuousEffects<T>(Card card) where T : ContinuousEffect
        {
            return ContinuousEffects.OfType<T>().Where(x => x.Filters.All(f => f.Applies(card, this, GetPlayer(card.Owner))));
        }

        public IEnumerable<Card> GetChoosableBattleZoneCreatures(Player selector)
        {
            return BattleZone.GetCreatures(selector.Id).Union(BattleZone.GetCreatures(GetOpponent(selector.Id)).Where(x => !GetContinuousEffects<UnchoosableEffect>(x).Any()));
        }

        public void Lose(Player player)
        {
            Losers.Add(player);
            _ = Players.Remove(player);
            Process(new LoseEvent(player.Copy()));
        }

        public void Win(Player player)
        {
            Winner = player;
            Process(new WinEvent(player.Copy()));
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
            _ = Move(new List<Card> { card }, source, destination);
        }

        /// <summary>
        /// Moving a card into the battle zone may require a choice to be made (eg. Petrova)
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// 
        /// <returns></returns>
        public IEnumerable<CardMovedEvent> Move(IEnumerable<Card> cards, ZoneType source, ZoneType destination)
        {
            return Move(cards.Select(x => new CardMovedEvent(x.Owner, x.Id, source, destination)).ToList());
        }

        private IEnumerable<CardMovedEvent> Move(List<CardMovedEvent> events)
        {
            // TODO: Sort players by turn order
            var effects = GetReplacementEffects(events);
            var affectedCardGroups = effects.Select(x => x.EventToReplace).Cast<CardMovedEvent>().Select(x => x.CardInSourceZone).GroupBy(x => GetCard(x).Owner);
            foreach (var cardGroup in affectedCardGroups)
            {
                var effectGroups = effects.Where(x => cardGroup.Contains((x.EventToReplace as CardMovedEvent).CardInSourceZone));
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
                Process(e);
            }
            return events;
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
            _ = Move(cards, ZoneType.Hand, ZoneType.Graveyard);
        }

        public void PutFromShieldZoneToHand(Card card, bool canUseShieldTrigger)
        {
            PutFromShieldZoneToHand(new List<Card> { card }, canUseShieldTrigger);
        }

        public void PutFromShieldZoneToHand(IEnumerable<Card> cards, bool canUseShieldTrigger)
        {
            var events = Move(cards, ZoneType.ShieldZone, ZoneType.Hand);
            if (canUseShieldTrigger)
            {
                var shieldTriggers = events.Where(x => x.Destination == ZoneType.Hand).Select(x => TryGetCard(x.CardInDestinationZone)).Where(x => x != null && x.ShieldTrigger);
                while (shieldTriggers.Any())
                {
                    var triggerGroups = shieldTriggers.GroupBy(x => x.Owner);
                    foreach (var group in triggerGroups)
                    {
                        var player = GetPlayer(group.Key);
                        var decision = player.Choose(new GuidSelection(player.Id, group.Select(x => x.Id), 0, 1));
                        if (decision.Decision.Any())
                        {
                            var trigger = GetCard(decision.Decision.Single());
                            shieldTriggers = shieldTriggers.Where(x => x.Id != trigger.Id);
                            Process(new ShieldTriggerEvent(player.Copy(), new Card(trigger, true)));
                            UseCard(trigger, player);
                        }
                        else
                        {
                            shieldTriggers = shieldTriggers.Where(x => !group.Select(y => y.Id).Contains(x.Id));
                        }
                    }
                }
            }
        }
        #endregion Methods
    }
}
