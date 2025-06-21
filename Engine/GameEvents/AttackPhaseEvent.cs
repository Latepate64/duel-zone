using System.Collections.Generic;
using System.Linq;

namespace Engine.GameEvents;

public class AttackPhaseEvent(IPlayerV2 player) : GameEventV2(player, false)
{
    internal override IEnumerable<GameEventV2> Happen(GameState state)
    {
        // TODO: Check if the creatures actually have a legal way to attack
        // TODO: Consider that creature with summoning sickness may be able to attack
        var creatures = state.BattleZone.GetUntappedCreatures(state.ActivePlayer);
        if (creatures.Any(x => !x.SummoningSickness))
        {
            return [new AttackEvent(Player)];
        }
        return [];
    }
}