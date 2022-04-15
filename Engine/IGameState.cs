using Engine.Abilities;
using Engine.Zones;
using System.Collections.Generic;

namespace Engine
{
    public interface IGameState : ICopyable<IGameState>
    {
        IBattleZone BattleZone { get; }

        /// <summary>
        /// 603.7. An effect may create a delayed triggered ability that can do something at a later time.
        /// A delayed triggered ability will contain “when,” “whenever,” or “at,” although that word won’t usually begin the ability.
        /// </summary>
        List<DelayedTriggeredAbility> DelayedTriggeredAbilities { get; }

        IList<IPlayer> Players { get; }
        SpellStack SpellStack { get; }
    }
}
