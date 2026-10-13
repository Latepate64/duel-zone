using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM12;

public sealed class Gigarayze : Creature
{
    public Gigarayze() : base("Gigarayze", 4, 2000, Race.Chimera,
        Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new SalvageEffect(
                    minimum: 0,
                    maximum: 1,
                    filter: new CivilizationCreatureFilter(
                        Civilization.Water,
                        Civilization.Fire),
                    excludeSource: false,
                    selectionRange: SelectionRange.OwnCreatures
        )));
    }
}
