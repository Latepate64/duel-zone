using Common;

namespace Cards.Cards.DM10
{
    class UliyaTheEntrancer : Creature
    {
        public UliyaTheEntrancer() : base("Uliya, the Entrancer", 6, Civilization.Darkness, 5000, Subtype.DarkLord)
        {
            Abilities.Add(new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.ShieldRecoveryEffect(true)));
        }
    }
}
