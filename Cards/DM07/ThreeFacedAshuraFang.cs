using TriggeredAbilities;

namespace Cards.DM07
{
    sealed class ThreeFacedAshuraFang : Creature
    {
        public ThreeFacedAshuraFang() : base("Three-Faced Ashura Fang", 4, 4000, Interfaces.Race.DevilMask, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ShieldRecoveryCannotUseShieldTriggerEffect()));
        }
    }
}
