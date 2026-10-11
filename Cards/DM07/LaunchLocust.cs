using CardFilters;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM07;

sealed class LaunchLocust : Creature
{
    public LaunchLocust() : base("Launch Locust", 3, 2000, Race.HornedBeast,
        Civilization.Nature)
    {
        AddStaticAbilities(
            new WhileAttackingGetPowerForEachOfYourOtherCreaturesEffect(
                1000, new CreatureFilter()));
    }
}
