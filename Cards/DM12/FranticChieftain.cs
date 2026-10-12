using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM12;

public sealed class FranticChieftain : Creature
{
    public FranticChieftain() : base("Frantic Chieftain", 2, 2000, Race.Merfolk,
        Civilization.Water)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new BounceEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new MaxCostCreatureFilter(4),
                    selectionRange: SelectionRange.OwnCreatures
        )));
    }
}
