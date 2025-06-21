using Engine;
using Interfaces;

namespace OneShotEffects;

public abstract class FromGraveyardIntoManaZoneEffect : CardMovingChoiceEffect<ICard>
{
    protected FromGraveyardIntoManaZoneEffect(FromGraveyardIntoManaZoneEffect effect) : base(effect)
    {
    }

    protected FromGraveyardIntoManaZoneEffect(int minimum, int maximum, bool controllerChooses) : base(minimum, maximum, controllerChooses, ZoneType.Graveyard, ZoneType.ManaZone)
    {
    }
}
