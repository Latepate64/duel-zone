using Common;

namespace Cards.Cards.DM10
{
    class BenzoTheHiddenFury : Creature
    {
        public BenzoTheHiddenFury() : base("Benzo, the Hidden Fury", 4, 2000, Engine.Subtype.PandorasBox, Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ShieldRecoveryCanUseShieldTriggerEffect());
        }
    }
}
