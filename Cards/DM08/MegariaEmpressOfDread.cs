using StaticAbilities;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;

namespace Cards.DM08;

sealed class MegariaEmpressOfDread : Creature
{
    public MegariaEmpressOfDread(
        EachCreatureHasAbilitiesEffectFactory eachCreatureHasAbilityEffectFactory,
        CreatureFilter creatureFilter,
        SlayerAbilityFactory slayerAbilityFactory
    ) : base("Megaria, Empress of Dread", 5, 5000, Race.DarkLord,
        Civilization.Darkness)
    {
        AddStaticAbilities(
            eachCreatureHasAbilityEffectFactory.Create(
                creatureFilter,
                slayerAbilityFactory.Create()
            )
        );
    }
}
