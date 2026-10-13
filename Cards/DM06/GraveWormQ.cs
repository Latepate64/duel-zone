using TriggeredAbilities;
using OneShotEffects;
using Interfaces;
using CardFilters;

namespace Cards.DM06;

sealed class GraveWormQ : Creature
{
    public GraveWormQ() : base("Grave Worm Q", 5, 3000, [Race.Survivor,
        Race.ParasiteWorm], Civilization.Darkness)
    {
        AddStaticAbilities(
            new SurvivorEffect(
                new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                    new SalvageEffect(
                    minimum: 0,
                    maximum: 1,
                    filter: new RaceCreatureFilter(Race.Survivor),
                    excludeSource: false,
                    selectionRange: SelectionRange.OwnCreatures
        ))));
    }
}