using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM03;

sealed class BaragaBladeOfGloom : Creature
{
    public BaragaBladeOfGloom() : base("Baraga, Blade of Gloom", 4, 4000,
        Race.DarkLord, Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new ShieldRecoveryEffect(
                    minimum: 1,
                    maximum: 1, 
                    controllerChooses: true, 
                    canUseShieldTrigger: false)));
    }
}