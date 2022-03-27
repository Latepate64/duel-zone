using Common;
using Engine;

namespace Cards.OneShotEffects
{
    abstract class DestroyEffect : CardMovingChoiceEffect
    {
        protected DestroyEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses, ZoneType.BattleZone, ZoneType.Graveyard)
        {
        }

        protected DestroyEffect(DestroyEffect effect) : base(effect)
        {
        }
    }
}
