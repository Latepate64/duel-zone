using OneShotEffects;
using Engine;

namespace Cards.OneShotEffects
{
    abstract class ShieldBurnEffect : CardMovingChoiceEffect<Card>
    {
        protected ShieldBurnEffect(ShieldBurnEffect effect) : base(effect)
        {
        }

        protected ShieldBurnEffect(int minimum, int maximum, bool controllerChooses) : base(minimum, maximum, controllerChooses, ZoneType.ShieldZone, ZoneType.Graveyard)
        {
        }
    }
}
