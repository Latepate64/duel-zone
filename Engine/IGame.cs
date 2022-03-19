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
        BattleZone BattleZone { get; set; }
        IList<ITurn> Turns { get; }
        ITurn CurrentTurn { get; }
        Queue<IGameEvent> PreGameEvents { get; }
        Stack<ITurn> ExtraTurns { get; }

        /// <summary>
        /// 104.1. A game ends immediately when a player wins, when the game is a draw, or when the game is restarted.
        /// </summary>
        bool Ended { get; }

        void AddContinuousEffects(IAbility source, params ContinuousEffect[] continuousEffects);
        void AddContinuousEffects(ICard source, params StaticAbility[] staticAbilities);
        void AddDelayedTriggeredAbility(TriggeredAbility ability, Duration duration);
        void Battle(Guid attackingCreatureId, Guid defendingCreatureId);
        bool CanEvolve(Card card);
        void Destroy(IEnumerable<ICard> cards);
        IEnumerable<ICard> GetAllCards();
        IEnumerable<ICard> GetAllCards(CardFilter filter, Guid player);
        Common.IIdentifiable GetAttackable(Guid id);
        ICard GetCard(Guid id);
        IEnumerable<ICard> GetChoosableBattleZoneCreatures(IPlayer selector);
        IEnumerable<T> GetContinuousEffects<T>(ICard card) where T : IContinuousEffect;
        IEnumerable<ICard> GetCreaturesCreatureCanEvolveFrom(ICard card);
        IPlayer GetOpponent(IPlayer player);
        Guid GetOpponent(Guid player);
        IPlayer GetOwner(ICard card);
        IPlayer GetPlayer(Guid id);
        int GetTimestamp();
        void Lose(IPlayer player);
        IEnumerable<CardMovedEvent> Move(Common.ZoneType source, Common.ZoneType destination, params ICard[] cards);
        void Play(IPlayer startingPlayer, IPlayer otherPlayer);
        void Process(IGameEvent gameEvent);
        void PutFromShieldZoneToHand(IEnumerable<ICard> cards, bool canUseShieldTrigger);
        void RemoveContinuousEffects(IEnumerable<Guid> staticAbilities);
        void RemoveRevokedObjects(Type duration);
    }
}