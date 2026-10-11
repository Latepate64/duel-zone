using Abilities;
using Abilities.Static;
using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

sealed class LegionnaireLizard : Creature
{
    public LegionnaireLizard() : base("Legionnaire Lizard", 6, 4000,
        Race.DuneGecko, Civilization.Fire)
    {
        AddAbilities(
            new TapAbility(
                new OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect(
                    new SpeedAttackerAbility(),
                    new CreatureFilter()
                )));
    }
}