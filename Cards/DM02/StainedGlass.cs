using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM02;

public sealed class StainedGlass : Creature
{
    public StainedGlass() : base("Stained Glass", 3, 1000, Race.CyberVirus,
        Civilization.Water)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new CivilizationCreatureFilter(
                        Civilization.Fire, Civilization.Nature),
                    source: ZoneType.BattleZone,
                    destination: ZoneType.Hand,
                    selectionRange: SelectionRange.OpponentsCards
        )));
    }
}
