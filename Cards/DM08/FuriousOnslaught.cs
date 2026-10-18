using StaticAbilities;
using CardFilters;
using ContinuousEffects.AbilityAddingPowerModifying;
using Interfaces;
using OneShotEffects;

namespace Cards.DM08;

public sealed class FuriousOnslaught : Spell
{
    public FuriousOnslaught(
        YourCreaturesHaveRaceGetPowerAndHaveAbilityEffectFactory effectFactory,
        DoubleBreakerAbilityFactory abilityFactory,
        RaceCreatureFilterFactory filterFactory
        )
    : base("Furious Onslaught", 4, Civilization.Fire)
    {
        AddSpellAbilities(
            new AddYourCreaturesHaveRaceGetPowerAndHaveAbilityEffect(
                effectFactory,
                filterFactory.Create(Race.Dragonoid),
                Race.ArmoredDragon,
                4000,
                abilityFactory
            ));
    }
}
