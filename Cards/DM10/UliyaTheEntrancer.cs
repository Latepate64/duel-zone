using TriggeredAbilities;

namespace Cards.DM10
{
    class UliyaTheEntrancer : Engine.Creature
    {
        public UliyaTheEntrancer() : base("Uliya, the Entrancer", 6, 5000, Interfaces.Race.DarkLord, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ShieldRecoveryCanUseShieldTriggerEffect()));
        }
    }
}
