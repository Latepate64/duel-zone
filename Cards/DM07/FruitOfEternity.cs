namespace Cards.DM07
{
    class FruitOfEternity : Engine.Spell
    {
        public FruitOfEternity() : base("Fruit of Eternity", 4, Engine.Civilization.Nature)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.WheneverAnyOfYourCreaturesWouldBeDestroyedThisTurnPutItIntoYourManaZoneInsteadEffect());
        }
    }
}
