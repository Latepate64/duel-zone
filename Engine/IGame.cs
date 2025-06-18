using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using Engine.Zones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public interface IGame
    {
        BattleZone BattleZone { get; }
        Turn CurrentTurn { get; }
        /// <summary>
        /// 104.1. A game ends immediately when a player wins, when the game is a draw, or when the game is restarted.
        /// </summary>
        bool Ended { get; }

        Stack<Turn> ExtraTurns { get; }
        IEnumerable<Player> Players { get; }
        Queue<IGameEvent> PreGameEvents { get; }
        SpellStack SpellStack { get; }
        IList<Turn> Turns { get; }
        public IContinuousEffects ContinuousEffects { get; }
        Player ActivePlayer => CurrentTurn.ActivePlayer;

        void AddAbility(Card card, IAbility ability);

        void AddContinuousEffects(IAbility source, params IContinuousEffect[] continuousEffects);
        void AddDelayedTriggeredAbility(DelayedTriggeredAbility ability);

        void AddPendingAbilities(params IResolvableAbility[] abilities);

        void AddReflexiveTriggeredAbility(IResolvableAbility ability);

        bool AffectedBySummoningSickness(Creature creature);
        void Battle(Card attackingCreature, Card defendingCreature);

        void Break(Creature creature, int breakAmount);

        bool CanAttackAtLeastOneCreature(Creature creature);
        bool CanAttackAtLeastSomething(Creature creature) => CanAttackAtLeastOneCreature(creature) || CanAttackPlayers(creature);

        bool CanAttackCreature(Card attacker, Card targetOfAttack);

        bool CanAttackPlayers(Creature creature);

        bool CanBeUsedRegardlessOfManaCost(Card card);

        bool CheckStateBasedActions();

        void Destroy(IAbility ability, params Creature[] cards);

        IAbility GetAbility(Guid id);

        IEnumerable<Card> GetAllCards();

        IAttackable GetAttackable(Guid id);

        Card GetCard(Guid id);

        IEnumerable<Creature> GetChoosableCreaturesControlledByAnyone(IGame game, Guid id) => BattleZone.GetChoosableCreaturesControlledByAnyone(game, id);
        IEnumerable<Creature> GetCreaturesThatHaveAttackTargets();
        Player GetOpponent(Player player);
        Guid GetOpponent(Guid player);
        Player GetOwner(Card card);
        Player GetPlayer(Guid id);
        IEnumerable<IAttackable> GetPossibleAttackTargets(Creature attacker);
        int GetTimestamp();
        Zone GetZone(Card card);

        void Lose(params Player[] players);
        IEnumerable<IGameEvent> Move(IAbility ability, ZoneType source, ZoneType destination, params Card[] cards);
        IEnumerable<IGameEvent> MoveTapped(IAbility ability, ZoneType hand, ZoneType manaZone, params Card[] cards);
        void MoveTopCard(Card card, ZoneType destination, IAbility ability);
        void Play(Player startingPlayer, Player otherPlayer);
        IEnumerable<IGameEvent> ProcessEvents(params IGameEvent[] gameEvents);
        void PutFromShieldZoneToHand(IEnumerable<Card> cards, bool canUseShieldTrigger, IAbility ability);
        void ResolveReflexiveTriggeredAbilities();
        int GetAmountOfShieldsCreatureBreaks(Creature attackingCreature);
        void ProcessCreatureAttackedEvent(Creature attacker, IAttackable target);
        void AddPendingSilentSkillAbilities(IEnumerable<Creature> cards);
        IEnumerable<Creature> GetBattleZoneCreatures(Player player) => BattleZone.GetCreatures(player);
        IEnumerable<Creature> GetBattleZoneCreaturesWithSilentSkill(Player player) => BattleZone.GetCreaturesWithSilentSkill(player);
        void RemoveSummoningSicknesses(Player player) => BattleZone.RemoveSummoningSicknesses(player);
        bool CanPlayerUntapTheCardsInTheirManaZoneAtTheStartOfEachOfTheirTurns(Player player) => ContinuousEffects.CanPlayerUntapTheCardsInTheirManaZoneAtTheStartOfEachOfTheirTurns(player);
        bool DoCreaturesInTheBattleZoneUntapAtTheStartOfEachPlayersTurn() => ContinuousEffects.DoCreaturesInTheBattleZoneUntapAtTheStartOfEachPlayersTurn();
        int GetAmountOfBattleZoneCreatures(Player player) => GetBattleZoneCreatures(player).Count();
    }
}