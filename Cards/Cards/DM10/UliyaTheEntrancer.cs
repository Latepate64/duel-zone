using Common;

namespace Cards.Cards.DM10
{
    class UliyaTheEntrancer : Creature
    {
        public UliyaTheEntrancer() : base("Uliya, the Entrancer", 6, 5000, Subtype.DarkLord, Civilization.Darkness)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsPutIntoTheBattleZoneAbility(new OneShotEffects.ShieldRecoveryEffect(true)));
        }
    }
}
