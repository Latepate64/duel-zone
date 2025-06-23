namespace Cards.DM06
{
    sealed class FaerieLife : Spell
    {
        public FaerieLife() : base("Faerie Life", 2, Interfaces.Civilization.Nature)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.PutTopCardOfDeckIntoManaZoneEffect());
        }
    }
}
