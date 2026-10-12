using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

sealed class MinelordSkyterror : SilentSkillCreature
{
    public MinelordSkyterror() : base("Minelord Skyterror", 4, 3000,
        Race.ArmoredWyvern, Civilization.Fire)
    {
        AddSilentSkillAbility(
            new DestroyAllCreaturesEffect(
                    new MaxPowerFilter(3000)));
    }
}