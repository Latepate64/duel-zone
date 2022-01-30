using Engine;
using Engine.Zones;

namespace Cards.OneShotEffects
{
    class DestroyEffect : CardMovingChoiceEffect
    {
        public DestroyEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses, ZoneType.BattleZone, ZoneType.Graveyard)
        {
        }
    }
}
