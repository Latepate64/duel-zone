namespace Cards.DM03
{
    class SundropArmor : Engine.Spell
    {
        public SundropArmor() : base("Sundrop Armor", 4, Interfaces.Civilization.Light)
        {
            AddSpellAbilities(new OneShotEffects.AddCardFromYourHandToYourShieldsFaceDownEffect());
        }
    }
}
