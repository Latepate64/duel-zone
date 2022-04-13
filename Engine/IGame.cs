using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using Engine.Zones;
using System;
using System.Collections.Generic;

namespace Engine
{
    public interface IGame
    {
        IList<IPlayer> Players { get; }
        IBattleZone BattleZone { get; set; }
        IList<ITurn> Turns { get; }
        ITurn CurrentTurn { get; }
        Queue<IGameEvent> PreGameEvents { get; }
        Stack<ITurn> ExtraTurns { get; }

        /// <summary>
        /// 104.1. A game ends immediately when a player wins, when the game is a draw, or when the game is restarted.
        /// </summary>
        bool Ended { get; }
        SpellStack SpellStack { get; }

        void AddAbility(ICard card, IAbility ability);
        bool CheckStateBasedActions();
        void AddContinuousEffects(IAbility source, params IContinuousEffect[] continuousEffects);
        void AddContinuousEffects(ICard source, params IStaticAbility[] staticAbilities);
        void AddDelayedTriggeredAbility(DelayedTriggeredAbility ability);
        void Battle(Guid attackingCreatureId, Guid defendingCreatureId);
        void AddReflexiveTriggeredAbility(IResolvableAbility ability);
        bool CanEvolve(ICard card);
        void Destroy(IEnumerable<ICard> cards);
        IAbility GetAbility(Guid id);
        IEnumerable<ICard> GetAllCards();
        Common.IIdentifiable GetAttackable(Guid id);
        ICard GetCard(Guid id);
        IEnumerable<T> GetContinuousEffects<T>() where T : IContinuousEffect;
        IEnumerable<ICard> GetCreaturesCreatureCanEvolveFrom(ICard card);
        IEnumerable<ICard> GetCreaturesThatHaveAttackTargets();
        IPlayer GetOpponent(IPlayer player);
        Guid GetOpponent(Guid player);
        IPlayer GetOwner(ICard card);
        IPlayer GetPlayer(Guid id);
        IEnumerable<Common.IIdentifiable> GetPossibleAttackTargets(ICard attacker);
        int GetTimestamp();
        void Lose(params IPlayer[] players);
        IEnumerable<IGameEvent> Move(Common.ZoneType source, Common.ZoneType destination, params ICard[] cards);
        IEnumerable<IGameEvent> MoveTapped(Common.ZoneType hand, Common.ZoneType manaZone, params ICard[] cards);
        void Play(IPlayer startingPlayer, IPlayer otherPlayer);
        IEnumerable<IGameEvent> ProcessEvents(params IGameEvent[] gameEvents);
        void PutFromShieldZoneToHand(IEnumerable<ICard> cards, bool canUseShieldTrigger);
        void RemoveContinuousEffects(IEnumerable<Guid> staticAbilities);
        void AddPendingAbilities(params IResolvableAbility[] abilities);
        IZone GetZone(ICard card);
        void ResolveReflexiveTriggeredAbilities();
    }
}