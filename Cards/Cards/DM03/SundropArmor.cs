using Common;

namespace Cards.Cards.DM03
{
    class SundropArmor : Spell
    {
        public SundropArmor() : base("Sundrop Armor", 4, Civilization.Light)
        {
            AddSpellAbilities(new OneShotEffects.AddCardFromYourHandToYourShieldsFaceDownEffect());
        }
    }
}
