namespace Cards.DM01
{
    sealed class AuraBlast : Spell
    {
        public AuraBlast() : base("Aura Blast", 4, Interfaces.Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.AuraBlastEffect(2000));
        }
    }
}
