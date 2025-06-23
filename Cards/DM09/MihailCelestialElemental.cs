using ContinuousEffects;
using Interfaces;

namespace Cards.DM09;

public sealed class MihailCelestialElemental : Creature
{
    public MihailCelestialElemental() : base(
        "Mihail, Celestial Elemental", 8, 4000, Race.AngelCommand, Civilization.Light)
    {
        AddStaticAbilities(new MihailCelestialElementalEffect());
    }
}
