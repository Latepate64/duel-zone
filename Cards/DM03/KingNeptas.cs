using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM03;

public sealed class KingNeptas : Creature
{
    public KingNeptas() : base("King Neptas", 6, 5000, Race.Leviathan,
        Civilization.Water)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new BounceEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new MaxPowerFilter(2000),
                    selectionRange: SelectionRange.AllCreatures
        )));
    }
}
