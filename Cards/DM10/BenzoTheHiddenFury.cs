using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM10;

sealed class BenzoTheHiddenFury : Creature
{
    public BenzoTheHiddenFury() : base("Benzo, the Hidden Fury", 4, 2000,
        Race.PandorasBox, Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new ShieldRecoveryEffect(
                    minimum: 1,
                    maximum: 1, 
                    controllerChooses: true, 
                    canUseShieldTrigger: true)));
    }
}