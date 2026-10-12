using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

sealed class VorgsEngine : SilentSkillCreature
{
    public VorgsEngine() : base("Vorg's Engine", 2, 2000, Race.Xenoparts,
        Civilization.Fire)
    {
        AddSilentSkillAbility(
            new DestroyAllCreaturesEffect(
                new MaxPowerFilter(2000)));
    }
}