using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM04;

public sealed class ReBilSeekerOfArchery : Creature
{
    public ReBilSeekerOfArchery() : base("Re Bil, Seeker of Archery", 7, 6000, Race.MechaThunder, Civilization.Light)
    {
        AddStaticAbilities(new EachOtherCivilizationCreaturePowerEffect(Civilization.Light, 2000));
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}
