using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM03;

public sealed class RoarOfTheEarth : Spell
{
    public RoarOfTheEarth() : base("Roar of the Earth", 2, Civilization.Nature)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new ManaRecoveryEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new MinCostCreatureFilter(6),
                selectionRange: SelectionRange.OwnCreatures
        ));
    }
}
