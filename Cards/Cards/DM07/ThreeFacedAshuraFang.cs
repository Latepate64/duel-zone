using Common;

namespace Cards.Cards.DM07
{
    class ThreeFacedAshuraFang : Creature
    {
        public ThreeFacedAshuraFang() : base("Three-Faced Ashura Fang", 4, 4000, Subtype.DevilMask, Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ShieldRecoveryCannotUseShieldTriggerEffect());
        }
    }
}
