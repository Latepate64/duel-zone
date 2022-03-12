﻿using Common;
using Common.GameEvents;
using Engine.Abilities;
using Common.Choices;
using Engine.ContinuousEffects;
using Engine.Durations;
using Engine.Zones;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Engine
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

        internal Ability GetAbility(Guid id)
        {
            var abilities = GetAllCards().SelectMany(x => x.GetAbilities<Ability>());
            var foo = abilities.Where(x => x.Id == id).ToList();
            return foo.SingleOrDefault();
        }

        /// <summary>
        /// The number of shields each player has at the start of a game. 
        /// </summary>
        public int StartingNumberOfShields { get; set; } = 5;

        /// <summary>
        /// The number of cards each player draw at the start of a game.
        /// </summary>
        public int StartingHandSize { get; set; } = 5;

        public Turn CurrentTurn => Turns.Last();

        public IEnumerable<GameEvent> GameEvents => _preGameEvents.Union(Turns.SelectMany(x => x.Phases).SelectMany(x => x.GameEvents));

        public string GameEventsText => string.Join(Environment.NewLine, GameEvents.Select(x => x.ToString()));

        /// <summary>
        /// All the turns of the game that have been or are processed, in order.
        /// </summary>
        public IList<Turn> Turns { get; } = new List<Turn>();

        /// <summary>
        /// 611.2a A continuous effect generated by the resolution of a spell or ability lasts as long as stated by the spell or ability creating it (such as “until end of turn”).
        /// If no duration is stated, it lasts until the end of the game.
        /// </summary>
        private readonly List<ContinuousEffect> _continuousEffects = new();

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

        internal Queue<GameEvent> _preGameEvents = new();
        private int _timestamp = 0;

        /// <summary>
        /// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
        /// </summary>
        public BattleZone BattleZone { get; set; } = new BattleZone(new List<Card>());

        public delegate void GameEventHandler(GameEvent gameEvent);

        public event GameEventHandler OnGameEvent;

        #region Methods
        public Game() { }

        public Game(Game game)
        {
            DelayedTriggeredAbilities = game.DelayedTriggeredAbilities.Select(x => new DelayedTriggeredAbility(x)).ToList();
            ExtraTurns = new Stack<Turn>(game.ExtraTurns.Select(x => new Turn(x)));
            StartingHandSize = game.StartingHandSize;
            StartingNumberOfShields = game.StartingNumberOfShields;
            //Losers = game.Losers.Select(x => x.Copy()).ToList();
            //Players = game.Players.Select(x => x.Copy()).ToList();
            //if (game.Winner != null)
            //{
            //    Winner = game.Winner.Copy();
            //}
            Turns = game.Turns.Select(x => new Turn(x)).ToList();
            _continuousEffects = game._continuousEffects.Select(x => x.Copy()).ToList();
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
                foreach (var x in _continuousEffects)
                {
                    x.Dispose();
                }
                _continuousEffects.Clear();
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
            while (Players.Any())
            {
                StartNewTurn(activePlayer.Convert(), nonActivePlayer.Convert());
                var tmp1 = activePlayer;
                var tmp2 = nonActivePlayer;
                activePlayer = tmp2;
                nonActivePlayer = tmp1;
            }
        }

        private void StartNewTurn(Common.Player activePlayer, Common.Player nonActivePlayer)
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

            // Battle event must be processed relative to both creatures.
            Process(new BattleEvent { Card = attackingCreature.Convert(), OtherCard = defendingCreature.Convert() });
            Process(new BattleEvent { Card = defendingCreature.Convert(), OtherCard = attackingCreature.Convert() });

            if (attackingCreature.Power.Value > defendingCreature.Power.Value)
            {
                Outcome(attackingCreature, defendingCreature);
            }
            else if (attackingCreature.Power.Value < defendingCreature.Power.Value)
            {
                Outcome(defendingCreature, attackingCreature);
            }
            else
            {
                Destroy(new List<Card> { attackingCreature, defendingCreature });
            }

            Process(new AfterBattleEvent());

            void Outcome(Card winner, Card loser)
            {
                Process(new WinBattleEvent { Card = winner.Convert() });
                var destroyed = new List<Card> { loser };
                if (GetContinuousEffects<SlayerEffect>(loser).ToList().Any())
                {
                    destroyed.Add(winner);
                }
                Destroy(destroyed);
            }
        }

        public IEnumerable<Card> GetAllCards()
        {
            return Players.SelectMany(x => x.CardsInNonsharedZones).Union(BattleZone.Cards);
        }

        public IEnumerable<Card> GetAllCards(CardFilter filter, Guid player)
        {
            return GetAllCards().Where(card => filter.Applies(card, this, GetPlayer(player)));
        }

        public void Destroy(IEnumerable<Card> cards)
        {
            _ = Move(ZoneType.BattleZone, ZoneType.Graveyard, cards.ToArray());
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
            var opponent = Players.SingleOrDefault(x => x.Id != player);
            return opponent != null ? opponent.Id : Guid.Empty;
        }

        /// <summary>
        /// 108.3. The owner of a card in the game is the player who started the game with it in their deck.
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public Player GetOwner(Card card)
        {
            return Players.SingleOrDefault(x => x.Id == card?.Owner);
        }

        public Card GetCard(Guid id)
        {
            return GetAllCards().SingleOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Returns a player who is still in the game.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Player if they are still in the game, null otherwise</returns>
        public Player GetPlayer(Guid id)
        {
            return Players.SingleOrDefault(x => x.Id == id);
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
                return null; // It is possible that the player/card no longers exists.
            }
        }

        public void Process(GameEvent gameEvent)
        {
            OnGameEvent?.Invoke(gameEvent);
            if (Turns.Any())
            {
                CurrentTurn.CurrentPhase.GameEvents.Enqueue(gameEvent);
                ApplyContinuousEffects();
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
                CurrentTurn.CurrentPhase.PendingAbilities.AddRange(abilities);
                foreach (var ability in abilities)
                {
                    Process(new AbilityTriggeredEvent { Ability = ability.Id });
                }
            }
            else
            {
                _preGameEvents.Enqueue(gameEvent);
            }
        }

        public IEnumerable<TriggeredAbility> GetAbilitiesThatTriggerFromCardsInBattleZone(GameEvent gameEvent)
        {
            var abilities = new List<TriggeredAbility>();
            foreach (var card in BattleZone.Cards)
            {
                abilities.AddRange(card.GetAbilities<TriggeredAbility>().Where(x => x.CanTrigger(gameEvent, this)).Select(x => x.Trigger(card.Id, card.Owner)));
            }
            return abilities;
        }

        public IEnumerable<T> GetContinuousEffects<T>(Card card) where T : ContinuousEffect
        {
            return _continuousEffects.OfType<T>().Where(x => x.Filter.Applies(card, this, GetPlayer(card.Owner)) && x.ConditionsApply(this));
        }

        public IEnumerable<Card> GetChoosableBattleZoneCreatures(Player selector)
        {
            return BattleZone.GetCreatures(selector.Id).Union(BattleZone.GetCreatures(GetOpponent(selector.Id)).Where(x => !GetContinuousEffects<UnchoosableEffect>(x).Any()));
        }

        public void Lose(Player player)
        {
            Losers.Add(player);
            Process(new LoseEvent { Player = player.Copy() });
            Leave(player);

            // 104.2a A player still in the game wins the game if that player’s opponents have all left the game. This happens immediately and overrides all effects that would preclude that player from winning the game.
            if (Players.Count == 1)
            {
                Win(Players.Single());
            }
        }

        private void Win(Player player)
        {
            Winner = player;
            Process(new WinEvent { Player = player.Copy() });
            Leave(player);
        }

        private void Leave(Player player)
        {
            _ = Players.Remove(player);
            _ = Move(ZoneType.BattleZone, ZoneType.Anywhere, BattleZone.Cards.Where(x => x.Owner == player.Id).ToArray());
        }

        public IEnumerable<CardMovedEvent> Move(ZoneType source, ZoneType destination, params Card[] cards)
        {
            return Move(cards.Select(x => new CardMovedEvent { Player = GetPlayer(x.Owner)?.Convert(), CardInSourceZone = x.Id, Source = source, Destination = destination }).ToList());
        }

        /// <summary>
        /// 400.6.
        /// If an object would move from one zone to another, determine what event is moving the object.
        /// If the object is moving to a public zone and its owner will be able to look at it in that zone,
        /// its owner looks at it to see if it has any abilities that would affect the move.
        /// If the object is moving to the battlefield, each other player who will be able to look at it in that zone does so.
        /// Then any appropriate replacement effects, whether they come from that object or from elsewhere, are applied to that event.
        /// If any effects or rules try to do two or more contradictory or mutually exclusive things to a particular object,
        /// that object’s controller—or its owner if it has no controller—chooses which effect to apply, and what that effect does.
        /// (Note that multiple instances of the same thing may be mutually exclusive; for example, two simultaneous “destroy” effects.)
        /// Then the event moves the object.
        /// </summary>
        /// <param name="events"></param>
        /// <returns></returns>
        private IEnumerable<CardMovedEvent> Move(List<CardMovedEvent> events)
        {
            //TODO: Refactor based on summary.

            // TODO: Sort players by turn order
            var replacementEffects = GetReplacementEffects(events);
            var affectedCardGroups = replacementEffects.Select(x => x.EventToReplace).Cast<CardMovedEvent>().Select(x => x.CardInSourceZone).GroupBy(x => GetCard(x).Owner);
            foreach (var cardGroup in affectedCardGroups)
            {
                var effectGroups = replacementEffects.Where(x => cardGroup.Contains((x.EventToReplace as CardMovedEvent).CardInSourceZone));
                var player = GetPlayer(cardGroup.Key);
                var effectGuid = effectGroups.Count() > 1
                    ? player.Choose(new ReplacementEffectSelection(player.Id, replacementEffects.Select(x => x.Id), 1, 1), this).Decision.Single()
                    : effectGroups.Select(x => x.Id).Single();
                var effect = effectGroups.Single(x => x.Id == effectGuid);
                var newEvent = effect.Apply(this, player);
                if (newEvent != null)
                {
                    events = events.Where(x => x.Id != effect.EventToReplace.Id).ToList();
                    events.Add(newEvent as CardMovedEvent);
                }
            }
            foreach (var e in events)
            {
                Move(e);
                Process(e);
            }
            return events;
        }

        private void Move(CardMovedEvent e)
        {
            if (e.Player != null)
            {
                var player = GetPlayer(e.Player.Id);
                var card = GetCard(e.CardInSourceZone);
                var removed = (e.Source == ZoneType.BattleZone ? BattleZone : player.GetZone(e.Source)).Remove(card, this);
                if (removed)
                {
                    if (e.Destination != ZoneType.Anywhere)
                    {
                        // 400.7. An object that moves from one zone to another becomes a new object with no memory of, or relation to, its previous existence.
                        // 613.7d An object receives a timestamp at the time it enters a zone.
                        var newObject = new Card(card, GetTimestamp());
                        (e.Destination == ZoneType.BattleZone ? BattleZone : player.GetZone(e.Destination)).Add(newObject, this);
                        e.CardInDestinationZone = newObject.Convert();
                    }
                }
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

        public void PutFromShieldZoneToHand(IEnumerable<Card> cards, bool canUseShieldTrigger)
        {
            var events = Move(ZoneType.ShieldZone, ZoneType.Hand, cards.ToArray());
            if (canUseShieldTrigger)
            {
                CheckShieldTriggers(events);
            }
        }

        private void CheckShieldTriggers(IEnumerable<CardMovedEvent> events)
        {
            var allShieldTriggers = events.Where(x => x.Destination == ZoneType.Hand).Select(x => GetCard(x.CardInDestinationZone.Id)).Where(x => x != null && x.ShieldTrigger);
            while (allShieldTriggers.Any())
            {
                var shieldTriggersByPlayers = allShieldTriggers.GroupBy(x => x.Owner);
                foreach (var shieldTriggersByPlayer in shieldTriggersByPlayers)
                {
                    var player = GetPlayer(shieldTriggersByPlayer.Key);
                    var decision = player.Choose(new ShieldTriggerSelection(player.Id, shieldTriggersByPlayer), this);
                    if (decision.Decision.Any())
                    {
                        var trigger = GetCard(decision.Decision.Single());
                        allShieldTriggers = allShieldTriggers.Where(x => x.Id != trigger.Id);
                        Process(new ShieldTriggerEvent { Player = player.Copy(), Card = trigger.Convert() });
                        player.UseCard(trigger, this);
                    }
                    else
                    {
                        allShieldTriggers = allShieldTriggers.Where(x => !shieldTriggersByPlayer.Select(y => y.Id).Contains(x.Id));
                    }
                }
            }
        }

        public void AddAbility(Card card, Ability ability)
        {
            card.AddGrantedAbility(ability);
            if (ability is StaticAbility staticAbility)
            {
                AddContinuousEffects(card, staticAbility);
            }
        }

        internal void AddContinuousEffects(Card source, params StaticAbility[] staticAbilities)
        {
            var effects = new List<ContinuousEffect>();
            foreach (var ability in staticAbilities)
            {
                foreach (var effect in ability.ContinuousEffects)
                {
                    var copy = effect.Copy();
                    copy.SourceAbility = ability.Id;

                    // 613.7a A continuous effect generated by a static ability has the same timestamp as the object the static ability is on,
                    // or the timestamp of the effect that created the ability, whichever is later.
                    // If the effect that created the ability has the later timestamp and the object the ability is on receives a new timestamp,
                    // each continuous effect generated by static abilities of that object receives a new timestamp as well,
                    // but the relative order of those timestamps remains the same.
                    copy.Timestamp = source.Timestamp;

                    effects.Add(copy);
                }
            }
            _continuousEffects.AddRange(effects);
        }

        internal int GetTimestamp()
        {
            return _timestamp++;
        }

        internal void RemoveContinuousEffects(Type duration)
        {
            _ = _continuousEffects.RemoveAll(x => x.Duration.GetType() == duration);
        }

        internal void RemoveContinuousEffects(IEnumerable<Guid> staticAbilities)
        {
            _ = _continuousEffects.RemoveAll(x => staticAbilities.Contains(x.SourceAbility));
        }

        public void AddContinuousEffects(Ability source, params ContinuousEffect[] continuousEffects)
        {
            // 613.7b A continuous effect generated by the resolution of a spell or ability receives a timestamp at the time it’s created.
            continuousEffects.ToList().ForEach(x => { x.Timestamp = GetTimestamp(); x.SourceAbility = source.Id; });
            _continuousEffects.AddRange(continuousEffects);
        }

        /// <summary>
        /// 613. Interaction of Continuous Effects
        /// </summary>
        private void ApplyContinuousEffects()
        {
            // 613.1.The values of an object’s characteristics are determined by starting with the actual object.
            // For a card, that means the values of the characteristics printed on that card.
            GetAllCards().ToList().ForEach(x => x.ResetToPrintedValues());

            // TODO: 613.1d Layer 4: Type-changing effects are applied. These include effects that change an object’s card type, subtype, and / or supertype.

            // 613.1f Layer 6: Ability-adding effects, ability-removing effects, and effects that say an object can’t have an ability are applied.
            ApplyEffects<AbilityGrantingEffect>();

            // 613.1g Layer 7: Power-changing effects are applied.
            // 613.4c Layer 7c: Effects that modify power (but don’t set power to a specific number or value) are applied.
            ApplyEffects<PowerModifyingEffect>();

            // TODO: Should check if any characteristics have changed and provide that information as an event.
        }

        /// <summary>
        /// 613.2. Apply effects in a series of sublayers in the order described below.
        /// Within each sublayer, apply effects in timestamp order (see rule 613.7).
        /// Note that dependency may alter the order in which effects are applied within a sublayer. (See rule 613.8.)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private void ApplyEffects<T>() where T : CharacteristicModifyingEffect
        {
            _continuousEffects.OfType<T>().OrderBy(x => x.Timestamp).ToList().ForEach(x => x.CheckConditionsAndApply(this));
        }
        #endregion Methods
    }
}
