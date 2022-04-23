namespace Cards.Cards.DM06
{
    class FaerieLife : Spell
    {
        public FaerieLife() : base("Faerie Life", 2, Engine.Civilization.Nature)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.PutTopCardOfDeckIntoManaZoneEffect());
        }
    }
}
