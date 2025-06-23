using TriggeredAbilities;
using ContinuousEffects;
using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM08;

public sealed class TerradragonGamiratar : Creature
{
    public TerradragonGamiratar() : base("Terradragon Gamiratar", 4, 6000, Race.EarthDragon, Civilization.Nature)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new TerradragonGamiratarEffect()));
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}
