using TriggeredAbilities;

namespace Cards.Cards.DM10
{
    class UliyaTheEntrancer : Engine.Creature
    {
        public UliyaTheEntrancer() : base("Uliya, the Entrancer", 6, 5000, Engine.Race.DarkLord, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ShieldRecoveryCanUseShieldTriggerEffect()));
        }
    }
}
