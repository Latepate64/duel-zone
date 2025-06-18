namespace Cards.Cards.DM04
{
    class MysticInscription : Engine.Spell
    {
        public MysticInscription() : base("Mystic Inscription", 6, Engine.Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect());
        }
    }
}
