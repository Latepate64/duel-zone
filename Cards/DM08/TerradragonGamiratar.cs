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
                new StratosphereGiantEffect(
                    minimum: 0,
                    maximum: 1,
                    new CreatureFilter()
        )));
        AddAbilities(new DoubleBreakerAbility());
    }
}
