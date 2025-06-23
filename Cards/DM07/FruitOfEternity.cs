namespace Cards.DM07
{
    sealed class FruitOfEternity : Spell
    {
        public FruitOfEternity() : base("Fruit of Eternity", 4, Interfaces.Civilization.Nature)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.WheneverAnyOfYourCreaturesWouldBeDestroyedThisTurnPutItIntoYourManaZoneInsteadEffect());
        }
    }
}
