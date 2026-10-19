using Abilities;
using StaticAbilities;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

public sealed class MigasaAdeptOfChaos : Creature
{
    public MigasaAdeptOfChaos() : base("Migasa, Adept of Chaos", 3, 2000,
        Race.Human, Civilization.Fire)
    {
        AddAbilities(
            new TapAbility(
                new OneOfYourCreaturesGetsAbilityEffect(
                    new DoubleBreakerAbility(),
                    new CivilizationCreatureFilter(Civilization.Fire),
                    new ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffectFactory(),
                    new UntilEndOfThisTurnDuration()
                )));
    }
}
