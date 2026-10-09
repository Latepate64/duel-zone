using Abilities;
using Abilities.Static;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

public sealed class GandarSeekerOfExplosions : Creature
{
    public GandarSeekerOfExplosions() : base(
        "Gandar, Seeker of Explosions", 7, 6500, Race.MechaThunder, Civilization.Light)
    {
        AddAbilities(new DoubleBreakerAbility());
        AddAbilities(new TapAbility(new GandarSeekerOfExplosionsEffect()));
    }
}
