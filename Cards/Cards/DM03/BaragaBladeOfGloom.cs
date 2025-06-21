using TriggeredAbilities;

namespace Cards.Cards.DM03
{
    class BaragaBladeOfGloom : Engine.Creature
    {
        public BaragaBladeOfGloom() : base("Baraga, Blade of Gloom", 4, 4000, Engine.Race.DarkLord, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ShieldRecoveryCannotUseShieldTriggerEffect()));
        }
    }
}
