using StaticAbilities;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;

namespace Cards.DM03;

public sealed class ÜberdragonJabaha : EvolutionCreature
{
    public ÜberdragonJabaha(
        CivilizationCreatureFilterFactory civilizationCreatureFilterFactory,
        PowerAttackerAbilityFactory powerAttackerAbilityFactory
    ) : base("Überdragon Jabaha", 7, 11000, Race.ArmoredDragon, Civilization.Fire)
    {
        AddStaticAbilities(
            new EachOfYourOtherCreaturesHasAbilityEffect(
                civilizationCreatureFilterFactory.Create(Civilization.Fire),
                powerAttackerAbilityFactory.Create(2000)
            ));
        AddAbilities(new DoubleBreakerAbility());
    }
}
