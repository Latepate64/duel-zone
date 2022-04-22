namespace Cards.Cards.DM11
{
    class MorbidMedicine : Spell
    {
        public MorbidMedicine() : base("Morbid Medicine", 4, Engine.Civilization.Darkness)
        {
            AddSpellAbilities(new OneShotEffects.ReturnUpToTwoCreaturesFromYourGraveyardToYourHandEffect());
        }
    }
}
