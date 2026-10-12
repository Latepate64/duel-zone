using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM10;

sealed class GajirabuteVileCenturion : Creature
{
    public GajirabuteVileCenturion() : base("Gajirabute, Vile Centurion", 6,
        3000, Race.DemonCommand, Civilization.Darkness)
{
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new ShieldBurnEffect(
                    minimum: 1,
                    maximum: 1,
                    ownShields: false
        )));
    }
}