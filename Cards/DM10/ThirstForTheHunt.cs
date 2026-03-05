namespace Cards.DM10
{
    sealed class ThirstForTheHunt : Spell
    {
        public ThirstForTheHunt() : base("Thirst for the Hunt", 1, Interfaces.Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.AuraBlastEffect(1000));
        }
    }
}
