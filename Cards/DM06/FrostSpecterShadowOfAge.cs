using ContinuousEffects;
using Interfaces;

namespace Cards.DM06;

public sealed class FrostSpecterShadowOfAge : EvolutionCreature
{
    public FrostSpecterShadowOfAge() : base("Frost Specter, Shadow of Age", 3, 5000, Race.Ghost, Civilization.Darkness)
    {
        AddStaticAbilities(new FrostSpecterShadowOfAgeEffect());
    }
}
