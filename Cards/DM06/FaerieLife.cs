namespace Cards.DM06
{
    class FaerieLife : Engine.Spell
    {
        public FaerieLife() : base("Faerie Life", 2, Interfaces.Civilization.Nature)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.PutTopCardOfDeckIntoManaZoneEffect());
        }
    }
}
