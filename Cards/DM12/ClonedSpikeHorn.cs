using ContinuousEffects;
using Interfaces;

namespace Cards.DM12;

public sealed class ClonedSpikeHorn : Creature
{
    public ClonedSpikeHorn() : base("Cloned Spike-Horn", 4, 3000, Race.HornedBeast, Civilization.Nature)
    {
        AddStaticAbilities(new ClonedSpikeHornEffect(Name), new PoweredDoubleBreaker());
    }
}
