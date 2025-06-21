using System;
using System.Collections.Generic;
using System.Linq;
using Engine.Abilities;
using Interfaces;

namespace Engine.GameEvents;

public abstract class MoveCardEvent(IPlayerV2 player, ZoneType destination, bool passable) :
    GameEventV2(player, passable)
{
    public ZoneType Destination { get; } = destination;

    internal abstract ICard RemoveCardFromCurrentZone();

    internal override IEnumerable<GameEventV2> Happen(GameState state)
    {
        var card = RemoveCardFromCurrentZone();
        if (card == null)
        {
            return [];
        }
        if (Destination == ZoneType.Hand)
        {
            Player.Hand.Add(card);
            return [];
        }
        if (Destination == ZoneType.ManaZone)
        {
            // TODO: Multicolored tapped
            Player.ManaZone.Add(card);
            return [];
        }
        if (Destination == ZoneType.ShieldZone)
        {
            // TODO: Face down
            Player.ShieldZone.Add(card);
            return [];
        }
        if (Destination == ZoneType.BattleZone)
        {
            state.BattleZone.Add(card);
            state.ContinuousEffects.Add(card, [.. card.GetAbilities<IStaticAbility>().Where(
                x => x.FunctionZone == ZoneType.BattleZone)]);
            return [];
        }
        throw new NotImplementedException();
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is MoveCardEvent moveCardEvent
            && Destination == moveCardEvent.Destination;
    }
}