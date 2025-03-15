namespace Cards.Cards.DM10
{
    public class BenzoTheHiddenFury : Creature
    {
        public BenzoTheHiddenFury() : base("Benzo, the Hidden Fury", 4, 2000, Engine.Race.PandorasBox, Engine.Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ShieldRecoveryCanUseShieldTriggerEffect());
        }
    }
}
