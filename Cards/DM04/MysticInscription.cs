namespace Cards.DM04
{
    class MysticInscription : Engine.Spell
    {
        public MysticInscription() : base("Mystic Inscription", 6, Interfaces.Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect());
        }
    }
}
