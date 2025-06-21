namespace Cards.DM01
{
    class AuraBlast : Engine.Spell
    {
        public AuraBlast() : base("Aura Blast", 4, Interfaces.Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.AuraBlastEffect(2000));
        }
    }
}
