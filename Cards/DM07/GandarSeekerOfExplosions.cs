using ContinuousEffects;
using Engine;
using Engine.Abilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

public sealed class GandarSeekerOfExplosions : Creature
{
    public GandarSeekerOfExplosions() : base(
        "Gandar, Seeker of Explosions", 7, 6500, Race.MechaThunder, Civilization.Light)
    {
        AddStaticAbilities(new DoubleBreakerEffect());
        AddAbilities(new TapAbility(new GandarSeekerOfExplosionsEffect()));
    }
}
