using Abilities.Static;
using ContinuousEffects.CannotAttack;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM07;

sealed class Gigabuster : Creature
{
    public Gigabuster() : base("Gigabuster", 5, 5000, Race.Chimera,
        Civilization.Darkness)
    {
        AddAbilities(new BlockerAbility());
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new ShieldRecoveryEffect(
                    minimum: 1,
                    maximum: 1, 
                    controllerChooses: true, 
                    canUseShieldTrigger: false)));
        AddStaticAbilities(new ThisCreatureCannotAttackEffect());
    }
}