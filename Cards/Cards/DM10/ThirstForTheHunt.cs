namespace Cards.Cards.DM10
{
    class ThirstForTheHunt : Spell
    {
        public ThirstForTheHunt() : base("Thirst for the Hunt", 1, Engine.Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.AuraBlastEffect(1000));
        }
    }
}
