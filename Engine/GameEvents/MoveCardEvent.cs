using System;
using System.Collections.Generic;
using System.Linq;
using Engine.Abilities;

namespace Engine.GameEvents;

public abstract class MoveCardEvent(PlayerV2 player, ZoneType destination, bool passable) :
    GameEventV2(player, passable)
{
    public ZoneType Destination { get; } = destination;

    internal abstract Card RemoveCardFromCurrentZone();

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
            Player.ManaZone.Add(card);
            return [];
        }
        if (Destination == ZoneType.ShieldZone)
        {
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