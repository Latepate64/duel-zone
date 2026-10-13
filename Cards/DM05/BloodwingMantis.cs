using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;
using CardFilters;

namespace Cards.DM05;

public sealed class BloodwingMantis : Creature
{
    public BloodwingMantis() : base("Bloodwing Mantis", 5, 6000,
        Race.GiantInsect, Civilization.Nature)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new CardMovingChoiceEffect(
                    minimum: 2,
                    maximum: 2,
                    controllerChooses: true,
                    filter: new CreatureFilter(),
                    source: ZoneType.ManaZone,
                    destination: ZoneType.Hand,
                    selectionRange: SelectionRange.OwnCreatures
        )));
        AddAbilities(new DoubleBreakerAbility());
    }
}
