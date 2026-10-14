using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

sealed class LivingCitadelVosh : EvolutionCreature
{
    public LivingCitadelVosh() : base("Living Citadel Vosh", 5, 5000,
        Race.ColonyBeetle, Civilization.Nature)
    {
        AddStaticAbilities(
            new TapAbilityAddingEffect(
                new PutTopCardsOfDeckIntoManaZoneEffect(1),
                new CivilizationCreatureFilter(Civilization.Nature)));
    }
}