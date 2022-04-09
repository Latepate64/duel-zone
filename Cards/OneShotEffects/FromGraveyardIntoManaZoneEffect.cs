using Common;
using Engine;

namespace Cards.OneShotEffects
{
    abstract class FromGraveyardIntoManaZoneEffect : CardMovingChoiceEffect
    {
        protected FromGraveyardIntoManaZoneEffect(FromGraveyardIntoManaZoneEffect effect) : base(effect)
        {
        }

        protected FromGraveyardIntoManaZoneEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(minimum, maximum, controllerChooses, ZoneType.Graveyard, ZoneType.ManaZone)
        {
        }
    }
}
