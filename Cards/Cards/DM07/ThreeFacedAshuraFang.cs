using Abilities.Triggered;

namespace Cards.Cards.DM07
{
    class ThreeFacedAshuraFang : Engine.Creature
    {
        public ThreeFacedAshuraFang() : base("Three-Faced Ashura Fang", 4, 4000, Engine.Race.DevilMask, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ShieldRecoveryCannotUseShieldTriggerEffect()));
        }
    }
}
