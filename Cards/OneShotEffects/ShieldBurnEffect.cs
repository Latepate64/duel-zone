using Common;
using Engine;

namespace Cards.OneShotEffects
{
    abstract class ShieldBurnEffect : CardMovingChoiceEffect
    {
        protected ShieldBurnEffect(ShieldBurnEffect effect) : base(effect)
        {
        }

        protected ShieldBurnEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses, ZoneType.ShieldZone, ZoneType.Graveyard)
        {
        }
    }
}
