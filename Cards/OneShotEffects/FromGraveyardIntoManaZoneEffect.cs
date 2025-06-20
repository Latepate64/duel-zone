using OneShotEffects;
using Engine;

namespace Cards.OneShotEffects;

public abstract class FromGraveyardIntoManaZoneEffect : CardMovingChoiceEffect<Card>
{
    protected FromGraveyardIntoManaZoneEffect(FromGraveyardIntoManaZoneEffect effect) : base(effect)
    {
    }

    protected FromGraveyardIntoManaZoneEffect(int minimum, int maximum, bool controllerChooses) : base(minimum, maximum, controllerChooses, ZoneType.Graveyard, ZoneType.ManaZone)
    {
    }
}
