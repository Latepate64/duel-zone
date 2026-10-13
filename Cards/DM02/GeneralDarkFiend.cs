using Abilities.Static;
using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM02;

sealed class GeneralDarkFiend : Creature
{
    public GeneralDarkFiend() : base("General Dark Fiend", 5, 6000,
        Race.DarkLord, Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new ShieldBurnEffect(
                    minimum: 1,
                    maximum: 1,
                    filter: new AnyCardFilter(),
                    selectionRange: SelectionRange.OwnCreatures
        )));
        AddAbilities(new DoubleBreakerAbility());
    }
}