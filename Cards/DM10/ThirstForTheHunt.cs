namespace Cards.DM10
{
    class ThirstForTheHunt : Engine.Spell
    {
        public ThirstForTheHunt() : base("Thirst for the Hunt", 1, Engine.Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.AuraBlastEffect(1000));
        }
    }
}
