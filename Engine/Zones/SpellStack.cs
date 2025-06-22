using Interfaces;
using Interfaces.Zones;

namespace Engine.Zones;

public sealed class SpellStack : Zone, ISpellStack
{
    public SpellStack() : base(ZoneType.SpellStack)
    {
    }

    public SpellStack(Zone zone) : base(zone)
    {
    }

    public override IZone Copy()
    {
        return new SpellStack(this);
    }
}
