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
        ITurn CurrentTurn { get; }
        /// <summary>
        /// 104.1. A game ends immediately when a player wins, when the game is a draw, or when the game is restarted.
        /// </summary>
        bool Ended { get; }

        Stack<ITurn> ExtraTurns { get; }
        IEnumerable<IPlayer> Players { get; }
        Queue<IGameEvent> PreGameEvents { get; }
        SpellStack SpellStack { get; }
        IList<ITurn> Turns { get; }
        public IContinuousEffects ContinuousEffects { get; }
        IPlayer ActivePlayer => CurrentTurn.ActivePlayer;

        void AddAbility(Card card, IAbility ability);

        void AddContinuousEffects(IAbility source, params IContinuousEffect[] continuousEffects);
        void AddDelayedTriggeredAbility(DelayedTriggeredAbility ability);

        void AddPendingAbilities(params IResolvableAbility[] abilities);

        void AddReflexiveTriggeredAbility(IResolvableAbility ability);

        bool AffectedBySummoningSickness(Card creature);
        void Battle(Card attackingCreature, Card defendingCreature);

        void Break(Card creature, int breakAmount);

        bool CanAttackAtLeastOneCreature(Card creature);
        bool CanAttackAtLeastSomething(Card creature) => CanAttackAtLeastOneCreature(creature) || CanAttackPlayers(creature);

        bool CanAttackCreature(Card attacker, Card targetOfAttack);

        bool CanAttackPlayers(Card creature);

        bool CanBeUsedRegardlessOfManaCost(Card card);

        bool CheckStateBasedActions();

        void Destroy(IAbility ability, params Card[] cards);

        IAbility GetAbility(Guid id);

        IEnumerable<Card> GetAllCards();

        IAttackable GetAttackable(Guid id);

        Card GetCard(Guid id);

        IEnumerable<Card> GetChoosableCreaturesControlledByAnyone(IGame game, Guid id) => BattleZone.GetChoosableCreaturesControlledByAnyone(game, id);
        IEnumerable<Card> GetCreaturesThatHaveAttackTargets();
        IPlayer GetOpponent(IPlayer player);
        Guid GetOpponent(Guid player);
        IPlayer GetOwner(Card card);
        IPlayer GetPlayer(Guid id);
        IEnumerable<IAttackable> GetPossibleAttackTargets(Card attacker);
        int GetTimestamp();
        Zone GetZone(Card card);

        void Lose(params IPlayer[] players);
        IEnumerable<IGameEvent> Move(IAbility ability, ZoneType source, ZoneType destination, params Card[] cards);
        IEnumerable<IGameEvent> MoveTapped(IAbility ability, ZoneType hand, ZoneType manaZone, params Card[] cards);
        void MoveTopCard(Card card, ZoneType destination, IAbility ability);
        void Play(IPlayer startingPlayer, IPlayer otherPlayer);
        IEnumerable<IGameEvent> ProcessEvents(params IGameEvent[] gameEvents);
        void PutFromShieldZoneToHand(IEnumerable<Card> cards, bool canUseShieldTrigger, IAbility ability);
        void ResolveReflexiveTriggeredAbilities();
        int GetAmountOfShieldsCreatureBreaks(Card attackingCreature);
        void ProcessCreatureAttackedEvent(Card attacker, IAttackable target);
        void AddPendingSilentSkillAbilities(IEnumerable<Card> cards);
        IEnumerable<Card> GetBattleZoneCreatures(IPlayer player) => BattleZone.GetCreatures(player);
        IEnumerable<Card> GetBattleZoneCreaturesWithSilentSkill(IPlayer player) => BattleZone.GetCreaturesWithSilentSkill(player);
        void RemoveSummoningSicknesses(IPlayer player) => BattleZone.RemoveSummoningSicknesses(player);
        bool CanPlayerUntapTheCardsInTheirManaZoneAtTheStartOfEachOfTheirTurns(IPlayer player) => ContinuousEffects.CanPlayerUntapTheCardsInTheirManaZoneAtTheStartOfEachOfTheirTurns(player);
        bool DoCreaturesInTheBattleZoneUntapAtTheStartOfEachPlayersTurn() => ContinuousEffects.DoCreaturesInTheBattleZoneUntapAtTheStartOfEachPlayersTurn();
        int GetAmountOfBattleZoneCreatures(IPlayer player) => GetBattleZoneCreatures(player).Count();
    }
}