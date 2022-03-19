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
        List<IPlayer> Players { get; }
        BattleZone BattleZone { get; set; }
        IList<Turn> Turns { get; }
        Turn CurrentTurn { get; }
        Queue<GameEvent> PreGameEvents { get; }
        Stack<Turn> ExtraTurns { get; }

        void AddContinuousEffects(IAbility source, params ContinuousEffect[] continuousEffects);
        void AddContinuousEffects(ICard source, params StaticAbility[] staticAbilities);
        void AddDelayedTriggeredAbility(TriggeredAbility ability, Duration duration);
        bool CanEvolve(Card card);
        void Destroy(IEnumerable<ICard> cards);
        IEnumerable<ICard> GetAllCards();
        IEnumerable<ICard> GetAllCards(CardFilter filter, Guid player);
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
        void Process(GameEvent gameEvent);
        void PutFromShieldZoneToHand(IEnumerable<ICard> cards, bool canUseShieldTrigger);
        void RemoveContinuousEffects(IEnumerable<Guid> staticAbilities);
    }
}