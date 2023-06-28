using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using Engine.Zones;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Engine
{
    public class Game : IDisposable, IGame
    {
        public IContinuousEffects ContinuousEffects { get; }
        private readonly List<IResolvableAbility> _reflexiveTriggeredAbilities = new();

        private IGameState _state;
        private int _timestamp = 0;
        public Game()
        {
            ContinuousEffects = new ContinuousEffects.ContinuousEffects(this);
        }

        public Game(IGameState state)
        {
            _state = state;
        }

        public Game(Game game)
        {
            ExtraTurns = new Stack<ITurn>(game.ExtraTurns.Select(x => new Turn(x)));
            StartingHandSize = game.StartingHandSize;
            StartingNumberOfShields = game.StartingNumberOfShields;
            //Losers = game.Losers.Select(x => x.Copy()).ToList();
            //Players = game.Players.Select(x => x.Copy()).ToList();
            //if (game.Winner != null)
            //{
            //    Winner = game.Winner.Copy();
            //}
            Turns = game.Turns.Select(x => new Turn(x)).Cast<ITurn>().ToList();
            ContinuousEffects = ContinuousEffects.Copy();
            _state = _state.Copy();
            States = new Queue<IGameState>(States.Select(x => x.Copy()));
        }

        public delegate void GameEventHandler(IGameEvent gameEvent);

        public event GameEventHandler OnGameEvent;

        /// <summary>
        /// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
        /// </summary>
        public IBattleZone BattleZone => _state.BattleZone;

        public ITurn CurrentTurn => Turns.Last();

        /// <summary>
        /// 104.1. A game ends immediately when a player wins, when the game is a draw, or when the game is restarted.
        /// </summary>
        public bool Ended => !Players.Any();

        /// <summary>
        /// 500.7. Some effects can give a player extra turns.
        /// They do this by adding the turns directly after the specified turn.
        /// If a player is given multiple extra turns, the extra turns are added one at a time.
        /// If multiple players are given extra turns, the extra turns are added one at a time, in APNAP order (see rule 101.4).
        /// The most recently created turn will be taken first.
        /// </summary>
        public Stack<ITurn> ExtraTurns { get; private set; } = new Stack<ITurn>();

        public IEnumerable<IGameEvent> GameEvents => PreGameEvents.Union(Turns.SelectMany(x => x.Phases).SelectMany(x => x.GameEvents));

        public string GameEventsText => string.Join(Environment.NewLine, GameEvents.Select(x => x.ToString()));

        public ICollection<IPlayer> Losers { get; } = new Collection<IPlayer>();

        public int MaximumNumberOfTurns { get; set; } = 100;

        /// <summary>
        /// Players who are still in the game.
        /// </summary>
        //TODO: Should be reworked to return players in APNAP order, or make method for that.
        public IEnumerable<IPlayer> Players => _state.Players;

        public Queue<IGameEvent> PreGameEvents { get; } = new();

        public SpellStack SpellStack => _state.SpellStack;

        /// <summary>
        /// The number of cards each player draw at the start of a game.
        /// </summary>
        public int StartingHandSize { get; set; } = 5;

        /// <summary>
        /// The number of shields each player has at the start of a game.
        /// </summary>
        public int StartingNumberOfShields { get; set; } = 5;

        public Queue<IGameState> States { get; } = new();

        /// <summary>
        /// All the turns of the game that have been or are processed, in order.
        /// </summary>
        public IList<ITurn> Turns { get; } = new List<ITurn>();

        public IPlayer Winner { get; private set; }
        public IPlayer ActivePlayer => CurrentTurn.ActivePlayer;

        public void AddAbility(ICard card, IAbility ability)
        {
            card.AddGrantedAbility(ability);
            if (ability is IStaticAbility staticAbility)
            {
                ContinuousEffects.Add(card, staticAbility);
            }
        }

        public void AddContinuousEffects(IAbility source, params IContinuousEffect[] continuousEffects)
        {
            ContinuousEffects.Add(source, continuousEffects);
        }

        public void AddDelayedTriggeredAbility(DelayedTriggeredAbility delayedTriggeredAbility)
        {
            _state.DelayedTriggeredAbilities.Add(delayedTriggeredAbility);
        }

        public void AddPendingAbilities(params IResolvableAbility[] abilities)
        {
            CurrentTurn.CurrentPhase.PendingAbilities.AddRange(abilities);
        }

        public void AddReflexiveTriggeredAbility(IResolvableAbility ability)
        {
            _reflexiveTriggeredAbilities.Add(ability);
        }

        public bool AffectedBySummoningSickness(ICard creature)
        {
            return creature.SummoningSickness && (!ContinuousEffects.DoesCreatureHaveSpeedAttacker(creature) || !ContinuousEffects.DoesPlayerIgnoreAnyEffectsThatWouldPreventCreatureFromAttackingTheirOpponent(creature));
        }

        public void Battle(ICard attackingCreature, ICard defendingCreature)
        {
            ProcessEvents(new BattleEvent(attackingCreature, defendingCreature));
        }

        public void Break(ICard creature, int breakAmount)
        {
            ProcessEvents(new CreatureBreaksShieldsEvent(creature, breakAmount));
        }

        public bool CanAttackAtLeastOneCreature(ICard creature)
        {
            return ContinuousEffects.CanCreatureAttack(creature) && BattleZone.GetCreatures(creature.Owner.Opponent).Any(x => CanAttackCreature(creature, x));
        }

        public bool CanAttackCreature(ICard attacker, ICard targetOfAttack)
        {
            return ContinuousEffects.CanCreatureAttack(attacker) && ContinuousEffects.CanCreatureAttackCreature(attacker, targetOfAttack);
        }

        public bool CanAttackPlayers(ICard creature)
        {
            return (ContinuousEffects.CanCreatureAttack(creature) && ContinuousEffects.CanCreatureAttackPlayers(creature)) || ContinuousEffects.DoesPlayerIgnoreAnyEffectsThatWouldPreventCreatureFromAttackingTheirOpponent(creature);
        }

        public bool CanBeUsedRegardlessOfManaCost(ICard card)
        {
            return (!card.Supertypes.Contains(Supertype.Evolution) || ContinuousEffects.CanCreatureEvolve(card)) && ContinuousEffects.CanPlayerUseCard(card);
        }

        /// <summary>
        /// 704.3.
        /// Whenever a player would get priority, the game checks for any of the listed conditions for state-based actions, then performs all applicable state-based actions simultaneously as a single event.
        /// If any state-based actions are performed as a result of a check, the check is repeated; otherwise all triggered abilities that are waiting to be put on the stack are put on the stack, then the check is repeated.
        /// Once no more state-based actions have been performed as the result of a check and no triggered abilities are waiting to be put on the stack, the appropriate player gets priority.
        /// This process also occurs during the cleanup step (see rule 514), except that if no state-based actions are performed as the result of the step’s first check and no triggered abilities are waiting to be put on the stack, then no player gets priority and the step ends.
        /// </summary>
        /// <returns>True if check should be repeated, false otherwise.</returns>
        public bool CheckStateBasedActions()
        {
            var losers = new List<IPlayer>();
            losers.AddRange(CheckDirectAttack());
            losers.AddRange(CheckDeckout());
            var creaturesToDestroy = new List<ICard>();
            creaturesToDestroy.AddRange(CheckCreaturesWithPowerZeroOrLess());
            creaturesToDestroy.AddRange(CheckBattleLosses());
            //bool rearrange = CheckTopCardOfEvolutionCreatures();

            Destroy(null, creaturesToDestroy.Distinct().ToArray());
            Lose(losers.Distinct().ToArray());

            return losers.Any() || creaturesToDestroy.Any();// || rearrange;
        }

        public void Destroy(IAbility ability, params ICard[] cards)
        {
            _ = Move(ability, ZoneType.BattleZone, ZoneType.Graveyard, cards);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<ITriggeredAbility> GetAbilitiesThatTriggerFromCardsInBattleZone(IGameEvent gameEvent)
        {
            var abilities = new List<ITriggeredAbility>();
            foreach (var card in BattleZone.Cards)
            {
                abilities.AddRange(card.GetAbilities<ITriggeredAbility>().Where(x => x.CanTrigger(gameEvent)).Select(x => x.Trigger(card.Id, card.Owner.Id, gameEvent)));
            }
            return abilities;
        }

        public IAbility GetAbility(Guid id)
        {
            var abilities = GetAllCards().SelectMany(x => x.GetAbilities<IAbility>()).Union(CurrentTurn.CurrentPhase.PendingAbilities).Union(_reflexiveTriggeredAbilities);
            var foo = abilities.Where(x => x.Id == id).ToList();
            return foo.SingleOrDefault();
        }
        public IEnumerable<ICard> GetAllCards()
        {
            return Players.SelectMany(x => x.CardsInNonsharedZones).Union(BattleZone.Cards).Union(SpellStack.Cards);
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
                return Players.Single(x => x.Id == id);
            }
            else// if (BattleZone.Creatures.Any(x => x.Id == id))
            {
                return GetCard(id);
            }
            //else
            //{
            //    return null; // It is possible that the player/card no longers exists.
            //}
        }

        public ICard GetCard(Guid id)
        {
            return GetAllCards().SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<ICard> GetCreaturesThatHaveAttackTargets()
        {
            return BattleZone.GetCreatures(CurrentTurn.ActivePlayer).Where(c => !c.Tapped && !AffectedBySummoningSickness(c) && GetPossibleAttackTargets(c).Any());
        }

        public IEnumerable<IAttackable> GetPossibleAttackTargets(ICard attacker)
        {
            List<IAttackable> attackables = new();
            if (CanAttackPlayers(attacker))
            {
                attackables.Add(attacker.Owner.Opponent);
            }
            if (CanAttackAtLeastOneCreature(attacker))
            {
                var opponentsCreatures = BattleZone.GetCreatures(attacker.Owner.Opponent).Where(x => CanAttackCreature(attacker, x));
                attackables.AddRange(opponentsCreatures.Where(c => c.Tapped ||
                    ContinuousEffects.CanCreatureAttackUntappedCreature(attacker, c) ||
                    ContinuousEffects.CanCreatureBeAttackedAsThoughItWereTapped(c)));
            }
            if (attackables.Any() && attacker.GetAbilities<TapAbility>().Any() && !ContinuousEffects.CanPlayersUseTapAbilities())
            {
                attackables.Add(attacker);
            }
            return attackables;
        }

        public int GetTimestamp()
        {
            return _timestamp++;
        }

        public IZone GetZone(ICard card)
        {
            return GetZones().Single(x => x.Cards.Contains(card));
        }

        public void Lose(params IPlayer[] players)
        {
            foreach (var player in players)
            {
                Losers.Add(player);
                //TODO: Event
                //Process(new LoseEvent { Player = player.Copy() });
                Leave(player);
            }

            // 104.2a A player still in the game wins the game if that player’s opponents have all left the game.
            // This happens immediately and overrides all effects that would preclude that player from winning the game.
            if (Players.Count() == 1)
            {
                Win(Players.Single());
            }

            // 104.4a If all the players remaining in a game lose simultaneously, the game is a draw.

            // 800.4. Unlike two-player games, multiplayer games can
            // continue after one or more players have left the game.
            // TODO: Should check if game still has two or more players even if some players lose.
        }

        public IEnumerable<IGameEvent> Move(IAbility ability, ZoneType source, ZoneType destination, params ICard[] cards)
        {
            return ProcessEvents(cards.Where(x => x != null).Select(x => new CardMovedEvent(x.Owner, source, destination, x.Id, false, ability)).ToArray());
        }

        public IEnumerable<IGameEvent> MoveTapped(IAbility ability, ZoneType source, ZoneType destination, params ICard[] cards)
        {
            return ProcessEvents(cards.Select(x => new CardMovedEvent(x.Owner, source, destination, x.Id, true, ability)).ToArray());
        }

        public void MoveTopCard(ICard card, ZoneType destination, IAbility ability)
        {
            card.SeparateTopCard();
            Move(ability, ZoneType.BattleZone, destination, card);
        }

        public void Play(IPlayer startingPlayer, IPlayer otherPlayer)
        {
            // 103.1. At the start of a game, the players determine which one of them will choose who takes the first turn. In the first game of a match (including a single - game match), the players may use any mutually agreeable method (flipping a coin, rolling dice, etc.) to do so.In a match of several games, the loser of the previous game chooses who takes the first turn. If the previous game was a draw, the player who made the choice in that game makes the choice in this game.

            // 103.1. The player chosen to take the first turn is the starting player. The game’s default turn order begins with the starting player and proceeds clockwise.
            _state = new GameState(startingPlayer, otherPlayer);

            foreach (var card in GetAllCards())
            {
                card.InitializeAbilities();
            }

            // 103.2. After the starting player has been determined, each player shuffles their deck so that the cards are in a random order.
            Players.ToList().ForEach(x => x.ShuffleOwnDeck());

            // Each player puts five card from to the top of their deck into their shield zone.
            Players.ToList().ForEach(x => x.PutFromTopOfDeckIntoShieldZone(StartingNumberOfShields, null));

            // 103.4. Each player draws a number of cards equal to their starting hand size, which is normally five.
            Players.ToList().ForEach(x => x.DrawCards(StartingHandSize, null));

            // 103.7. The starting player takes their first turn.
            LoopTurns(startingPlayer, otherPlayer, MaximumNumberOfTurns);
        }

        public IEnumerable<IGameEvent> ProcessEvents(params IGameEvent[] events)
        {
            var effectsByEvent = GetReplacementEffectsByEvents(events);

            // TODO: Continue developing this logic so that player can choose between multiple continuous effects which one to apply, see mtg rule 616.1.
            //var toChoose = effectsByEvent.Where(x => x.Count() > 1);
            //var choices = toChoose.Select(group => new ReplacementEffectSelection(
            //    group.Key.GetApplier(this).Id,
            //    group.SelectMany(effects => effects.Select(effect => effect.Id))));
            //var decisions = MakeChoices(choices);

            // TODO: See above comment. Current implementation defaults to first replacement effect for each event that can be replaced by more than one effect.
            var finalEvents = effectsByEvent.Select(group =>
                group.Any(effects => effects.Any()) ?
                    group.SelectMany(effects => effects).First().Apply(group.Key, this) :
                    group.Key
            );
            finalEvents.ToList().ForEach(x => ProcessEvent(x));
            States.Enqueue(_state.Copy());
            return finalEvents;
        }

        /// <summary>
        /// TODO: Consider design independent of events returned by Move
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="canUseShieldTrigger"></param>
        public void PutFromShieldZoneToHand(IEnumerable<ICard> cards, bool canUseShieldTrigger, IAbility ability)
        {
            var events = Move(ability, ZoneType.ShieldZone, ZoneType.Hand, cards.ToArray());
            if (canUseShieldTrigger)
            {
                CheckShieldTriggers(events);
            }
        }

        public void ResolveReflexiveTriggeredAbilities()
        {
            while (_reflexiveTriggeredAbilities.Any())
            {
                //TODO: In rare cases there could be multiple reflexive triggered abilities, in that case those should be resolved in APNAP order
                var ability = _reflexiveTriggeredAbilities.First();
                _reflexiveTriggeredAbilities.RemoveAt(0);
                ability.Resolve();
            }
        }

        public override string ToString()
        {
            return $"{CurrentTurn}";
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
                foreach (var x in Turns)
                {
                    x.Dispose();
                }
                Turns.Clear();
                ContinuousEffects.Dispose();
            }
        }

        /// <summary>
        /// 101.4. If multiple players would make choices and/or take actions at the same time, the active player
        /// (the player whose turn it is) makes any choices required, then the next player in turn order (usually
        /// the player seated to the active player’s left) makes any choices required, followed by the remaining
        /// nonactive players in turn order.Then the actions happen simultaneously. This rule is often referred
        /// to as the “Active Player, Nonactive Player (APNAP) order” rule.
        /// </summary>
        /// <param name="choices"></param>
        /// <returns></returns>
        private static IEnumerable<Choices.IChoice> MakeChoices(IEnumerable<Choices.Choice> choices)
        {
            //TODO: Choose in APNAP order
            return choices.Select(choice => choice.Maker.Choose(choice));
        }

        /// <summary>
        /// DM703.4d A creature that lost in a battle is destroyed as a result of the battle.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<ICard> CheckBattleLosses()
        {
            var creatures = BattleZone.Creatures.Where(x => x.LostInBattle).ToList();
            creatures.ForEach(x => x.LostInBattle = false);
            return creatures;
        }

        /// <summary>
        /// DM703.4c A creature that has power 0 or less is destroyed.
        /// </summary>
        private IEnumerable<ICard> CheckCreaturesWithPowerZeroOrLess()
        {
            return BattleZone.Creatures.Where(x => x.Power <= 0);
        }

        /// <summary>
        /// DM703.4b If a player has no cards left in their deck, that player loses the game.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<IPlayer> CheckDeckout()
        {
            return Players.Where(X => X.Deck.Cards.Count == 0);
        }

        /// <summary>
        /// DM703.4a If a player was directly attacked while they had no shields and the attack wasn't redirected, that player loses the game.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<IPlayer> CheckDirectAttack()
        {
            return Players.Where(X => X.DirectlyAttacked);
        }

        private void CheckExpirations(IGameEvent gameEvent)
        {
            ContinuousEffects.RemoveExpired(gameEvent);
            foreach (var remove in _state.DelayedTriggeredAbilities.Where(x => x is IExpirable d && d.ShouldExpire(gameEvent)).ToArray())
            {
                _state.DelayedTriggeredAbilities.Remove(remove);
            }
        }

        /// <summary>
        /// TODO: Refactor and consider CannotUseShieldTriggerEffect
        /// </summary>
        /// <param name="events"></param>
        private void CheckShieldTriggers(IEnumerable<IGameEvent> events)
        {
            var allShieldTriggers = events.OfType<ICardMovedEvent>().Where(x => x.Destination == ZoneType.Hand).Select(x => GetCard(x.CardInDestinationZone.Id)).Where(x => x != null && x.ShieldTrigger);
            while (allShieldTriggers.Any())
            {
                var shieldTriggersByPlayers = allShieldTriggers.GroupBy(x => x.Owner);
                foreach (var shieldTriggersByPlayer in shieldTriggersByPlayers)
                {
                    var trigger = shieldTriggersByPlayer.Key.ChooseCardOptionally(shieldTriggersByPlayer, "You may use a shield trigger.");
                    if (trigger != null)
                    {
                        allShieldTriggers = allShieldTriggers.Where(x => x.Id != trigger.Id);
                        ProcessEvents(new ShieldTriggerEvent(shieldTriggersByPlayer.Key, trigger));
                    }
                    else
                    {
                        allShieldTriggers = allShieldTriggers.Where(x => !shieldTriggersByPlayer.Select(y => y.Id).Contains(x.Id));
                    }
                }
            }
        }

        /// <summary>
        /// DM703.4i When the top card of an Evolution Creature leaves the battle zone, the cards underneath it are reconstructed.
        /// </summary>
        /// <returns></returns>
        private bool CheckTopCardOfEvolutionCreatures()
        {
            return false; //TODO
        }

        /// <summary>
        /// Groups all applicable replacement effects for each simultaneous event.
        /// Example: If Mihail, Aqua Hulcus and Aqua Soldier controlled by the same player would be destroyed at the same time,
        /// the replacement effects for each destruction event would be as follows:
        /// none for Mihail, one for Hulcus (generated by Mihail), and two for Soldier (generated by Mihail and by itself).
        /// </summary>
        /// <param name="events"></param>
        /// <returns></returns>
        private IEnumerable<IGrouping<IGameEvent, IEnumerable<IReplacementEffect>>> GetReplacementEffectsByEvents(IGameEvent[] events)
        {
            return events.GroupBy(
                gameEvent => gameEvent,
                gameEvent => ContinuousEffects.GetReplacementEffectsThatCanBeApplied(gameEvent));
        }

        private IEnumerable<IZone> GetZones()
        {
            return Players.SelectMany(x => x.Zones).Union(new IZone[] { BattleZone });
        }

        private void Leave(IPlayer player)
        {
            // 800.4a When a player leaves the game, all objects (see rule 109) owned by that player leave the game.
            // TODO: Commented for time being, consider alternative design to avoid exceptions
            //_ = Move(ZoneType.BattleZone, ZoneType.Anywhere, BattleZone.Cards.Where(x => x.Owner == player.Id).ToArray());

            // 800.4a If that player controlled any objects on the stack not represented by cards, those objects cease to exist.
            // TODO: Commented for time being, consider alternative design to avoid exceptions
            //_ = CurrentTurn.CurrentPhase.PendingAbilities.RemoveAll(x => x.Controller == player.Id);
            _state.Players.Remove(player);
        }

        private void LoopTurns(IPlayer activePlayer, IPlayer nonActivePlayer, int turnsRemaining)
        {
            if (!Ended)
            {
                if (turnsRemaining > 0)
                {
                    StartNewTurn(activePlayer, nonActivePlayer);
                    LoopTurns(nonActivePlayer, activePlayer, turnsRemaining - 1);
                }
                else
                {
                    // 104.4b If a game that’s not using the limited range of influence option
                    // (including a two-player game) somehow enters a “loop” of mandatory actions,
                    // repeating a sequence of events with no way to stop, the game is a draw.
                    // Loops that contain an optional action don’t result in a draw.

                    // 104.5. If the game is a draw for a player, that player leaves the game.
                    Players.ToList().ForEach(x => Leave(x));
                }
            }
        }

        /// <summary>
        /// Note: Only call this method from ProcessEvents as it considers replacement effects.
        /// </summary>
        /// <param name="gameEvent"></param>
        private void ProcessEvent(IGameEvent gameEvent)
        {
            gameEvent.Happen(this);
            OnGameEvent?.Invoke(gameEvent);
            if (Turns.Any())
            {
                CurrentTurn.CurrentPhase.GameEvents.Enqueue(gameEvent);
                if (!Ended) //TODO: Consider better design
                {
                    NotifyWatchers(gameEvent);
                    CheckExpirations(gameEvent);
                    ContinuousEffects.Apply();
                    TriggerAbilities(gameEvent);
                }
            }
            else
            {
                PreGameEvents.Enqueue(gameEvent);
            }
        }

        private void NotifyWatchers(IGameEvent gameEvent)
        {
            BattleZone.Creatures.SelectMany(x => x.GetAbilities<IAbility>()).OfType<IWatcher>().ToList().ForEach(x => x.Watch(this, gameEvent));
            ContinuousEffects.Notify(gameEvent);
        }

        private void StartNewTurn(IPlayer activePlayer, IPlayer nonActivePlayer)
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

        private void TriggerAbilities(IGameEvent gameEvent)
        {
            var abilities = GetAbilitiesThatTriggerFromCardsInBattleZone(gameEvent).ToList();
            List<DelayedTriggeredAbility> toBeRemoved = new();
            foreach (var ability in _state.DelayedTriggeredAbilities.Where(x => x.TriggeredAbility.CanTrigger(gameEvent)))
            {
                abilities.Add(ability.TriggeredAbility.Copy() as ITriggeredAbility);
                if (ability.TriggersOnlyOnce)
                {
                    toBeRemoved.Add(ability);
                }
            }
            _ = _state.DelayedTriggeredAbilities.RemoveAll(x => toBeRemoved.Contains(x));
            AddPendingAbilities(abilities.ToArray());
        }

        private void Win(IPlayer player)
        {
            Winner = player;
            //TODO: Event
            //Process(new WinEvent { Player = player.Copy() });

            Leave(player); //TODO: Winner shouldn't leave?
        }

        public int GetAmountOfShieldsCreatureBreaks(ICard attackingCreature)
        {
            return ContinuousEffects.GetAmountsOfShieldsCreatureCanBreak(attackingCreature).DefaultIfEmpty(1).Max();
        }

        public void ProcessCreatureAttackedEvent(ICard attacker, IAttackable target)
        {
            ProcessEvents(new CreatureAttackedEvent(attacker, target));
        }

        public void AddPendingSilentSkillAbilities(IEnumerable<ICard> cards)
        {
            AddPendingAbilities(cards.SelectMany(x => x.GetSilentSkillAbilities()).ToArray());
        }

        public bool CanAttackAtLeastSomething(ICard creature) => CanAttackAtLeastOneCreature(creature) || CanAttackPlayers(creature);

        public IEnumerable<ICard> GetBattleZoneCreatures(IPlayer player) => BattleZone.GetCreatures(player);

        public IEnumerable<ICard> GetBattleZoneCreaturesWithSilentSkill(IPlayer player) => BattleZone.GetCreaturesWithSilentSkill(player);

        public void RemoveSummoningSicknesses(IPlayer player) => BattleZone.RemoveSummoningSicknesses(player);

        public bool CanPlayerUntapTheCardsInTheirManaZoneAtTheStartOfEachOfTheirTurns(IPlayer player) => ContinuousEffects.CanPlayerUntapTheCardsInTheirManaZoneAtTheStartOfEachOfTheirTurns(player);

        public bool DoCreaturesInTheBattleZoneUntapAtTheStartOfEachPlayersTurn() => ContinuousEffects.DoCreaturesInTheBattleZoneUntapAtTheStartOfEachPlayersTurn();

        public int GetAmountOfBattleZoneCreatures(IPlayer player) => GetBattleZoneCreatures(player).Count();
    }
}