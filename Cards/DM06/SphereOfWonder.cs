using Engine;
using Interfaces;

namespace Cards.DM06;

public sealed class SphereOfWonder : Spell
{
    public SphereOfWonder() : base("Sphere of Wonder", 4, Civilization.Light)
    {
        AddSpellAbilities(new SphereOfWonderEffect());
    }
}
