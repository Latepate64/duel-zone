using Common;

namespace Cards.Cards.DM04
{
    class MysticInscription : Spell
    {
        public MysticInscription() : base("Mystic Inscription", 6, Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect());
        }
    }
}
