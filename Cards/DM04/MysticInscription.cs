namespace Cards.DM04
{
    sealed class MysticInscription : Spell
    {
        public MysticInscription() : base("Mystic Inscription", 6, Interfaces.Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect());
        }
    }
}
