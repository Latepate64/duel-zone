using Common.GameEvents;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;
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

        void AddAbility(ICard card, IAbility ability);
        void AddContinuousEffects(IAbility source, params IContinuousEffect[] continuousEffects);
        void AddContinuousEffects(ICard source, params IStaticAbility[] staticAbilities);
        void AddDelayedTriggeredAbility(ITriggeredAbility ability, IDuration duration);
        void Battle(Guid attackingCreatureId, Guid defendingCreatureId);
        bool CanEvolve(ICard card);
        void Destroy(IEnumerable<ICard> cards);
        IAbility GetAbility(Guid id);
        IEnumerable<ICard> GetAllCards();
        IEnumerable<ICard> GetAllCards(ICardFilter filter, Guid player);
        Common.IIdentifiable GetAttackable(Guid id);
        ICard GetCard(Guid id);
        IEnumerable<ICard> GetChoosableBattleZoneCreatures(IPlayer selector);
        IEnumerable<T> GetContinuousEffects<T>(ICard card) where T : IContinuousEffect;
        IEnumerable<ICard> GetCreaturesCreatureCanEvolveFrom(ICard card);
        IEnumerable<ICard> GetCreaturesThatHaveAttackTargets();
        IPlayer GetOpponent(IPlayer player);
        Guid GetOpponent(Guid player);
        IPlayer GetOwner(ICard card);
        IPlayer GetPlayer(Guid id);
        IEnumerable<Common.IIdentifiable> GetPossibleAttackTargets(ICard attacker);
        int GetTimestamp();
        void Lose(IPlayer player);
        IEnumerable<ICardMovedEvent> Move(Common.ZoneType source, Common.ZoneType destination, params ICard[] cards);
        void Play(IPlayer startingPlayer, IPlayer otherPlayer);
        void Process(IGameEvent gameEvent);
        void PutFromShieldZoneToHand(IEnumerable<ICard> cards, bool canUseShieldTrigger);
        void RemoveContinuousEffects(IEnumerable<Guid> staticAbilities);
        void RemoveRevokedObjects(Type duration);
    }
}