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
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new CivilizationCreatureFilter(
                        Civilization.Water,
                        Civilization.Fire),
                    source: ZoneType.Graveyard,
                    destination: ZoneType.Hand,
                    selectionRange: SelectionRange.OwnCreatures
        )));
    }
}
