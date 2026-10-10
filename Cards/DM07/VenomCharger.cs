using Abilities.Static;
using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class VenomCharger : Charger
{
    public VenomCharger() : base("Venom Charger", 3, Civilization.Darkness)
    {
        AddSpellAbilities(
            new OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect(
                new SlayerAbility(),
                new CreatureFilter()
            ));
    }
}