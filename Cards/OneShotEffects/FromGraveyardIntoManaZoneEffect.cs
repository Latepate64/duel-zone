using Common;

namespace Cards.OneShotEffects
{
    abstract class FromGraveyardIntoManaZoneEffect : CardMovingChoiceEffect
    {
        protected FromGraveyardIntoManaZoneEffect(FromGraveyardIntoManaZoneEffect effect) : base(effect)
        {
        }

        protected FromGraveyardIntoManaZoneEffect(int minimum, int maximum, bool controllerChooses) : base(minimum, maximum, controllerChooses, ZoneType.Graveyard, ZoneType.ManaZone)
        {
        }
    }
}
