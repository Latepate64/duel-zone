namespace Cards.DM03
{
    sealed class SundropArmor : Spell
    {
        public SundropArmor() : base("Sundrop Armor", 4, Interfaces.Civilization.Light)
        {
            AddSpellAbilities(new OneShotEffects.AddCardFromYourHandToYourShieldsFaceDownEffect());
        }
    }
}
