using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using StaticAbilities;
using CardFilters;

namespace Cards.DM09;

public sealed class StratosphereGiant : Creature
{
    public StratosphereGiant() : base("Stratosphere Giant", 8, 13000,
        Race.Giant, Civilization.Nature)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 2,
                    controllerChooses: false,
                    filter: new CreatureFilter(),
                    source: ZoneType.Hand,
                    destination: ZoneType.BattleZone,
                    selectionRange: SelectionRange.OpponentsCards
        )));
        AddAbilities(new TripleBreakerAbility());
    }
}
