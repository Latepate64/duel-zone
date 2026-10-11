using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM02;

public sealed class PoisonWorm : Creature
{
    public PoisonWorm() : base("Poison Worm", 4, 4000, Race.ParasiteWorm,
        Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new DestroyEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new MaxPowerFilter(3000),
                    selectionRange: SelectionRange.OwnCreatures
                )));
    }
}
