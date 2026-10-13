using OneShotEffects;
using Abilities;
using Interfaces;
using CardFilters;

namespace Cards.DM07;

sealed class TangleFistTheWeaver : Creature
{
    public TangleFistTheWeaver() : base("Tangle Fist, the Weaver", 4, 2000,
        Race.BeastFolk, Civilization.Nature)
    {
        AddAbilities(
            new TapAbility(
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 3,
                    controllerChooses: true,
                    filter: new AnyCardFilter(),
                    source: ZoneType.Hand,
                    destination: ZoneType.ManaZone,
                    selectionRange: SelectionRange.OwnCreatures
        )));
    }
}