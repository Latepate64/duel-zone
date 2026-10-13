using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM01;

public sealed class ThornyMandra : Creature
{
    public ThornyMandra() : base("Thorny Mandra", 5, 4000, Race.TreeFolk,
        Civilization.Nature)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new CreatureFilter(),
                    source: ZoneType.Graveyard,
                    destination: ZoneType.ManaZone
        )));
    }
}
