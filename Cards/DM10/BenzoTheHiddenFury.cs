using TriggeredAbilities;

namespace Cards.DM10
{
    class BenzoTheHiddenFury : Engine.Creature
    {
        public BenzoTheHiddenFury() : base("Benzo, the Hidden Fury", 4, 2000, Interfaces.Race.PandorasBox, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ShieldRecoveryCanUseShieldTriggerEffect()));
        }
    }
}
