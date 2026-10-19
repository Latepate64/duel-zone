using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM07;

sealed class ThreeFacedAshuraFang : Creature
{
    public ThreeFacedAshuraFang() : base("Three-Faced Ashura Fang", 4, 4000,
        Race.DevilMask, Civilization.Darkness)
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