using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;
using CardFilters;

namespace Cards.DM08;

public sealed class TerradragonGamiratar : Creature
{
    public TerradragonGamiratar() : base("Terradragon Gamiratar", 4, 6000,
        Race.EarthDragon, Civilization.Nature)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: false,
                    filter: new CreatureFilter(),
                    ZoneType.Hand,
                    ZoneType.BattleZone
        )));
        AddAbilities(new DoubleBreakerAbility());
    }
}
