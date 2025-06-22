using TriggeredAbilities;

namespace Cards.DM03
{
    sealed class BaragaBladeOfGloom : Engine.Creature
    {
        public BaragaBladeOfGloom() : base("Baraga, Blade of Gloom", 4, 4000, Interfaces.Race.DarkLord, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ShieldRecoveryCannotUseShieldTriggerEffect()));
        }
    }
}
