namespace Cards.Cards.DM01
{
    class AuraBlast : Spell
    {
        public AuraBlast() : base("Aura Blast", 4, Common.Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.AuraBlastEffect(2000));
        }
    }
}
