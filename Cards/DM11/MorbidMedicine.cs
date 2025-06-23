namespace Cards.DM11
{
    sealed class MorbidMedicine : Spell
    {
        public MorbidMedicine() : base("Morbid Medicine", 4, Interfaces.Civilization.Darkness)
        {
            AddSpellAbilities(new OneShotEffects.ReturnUpToTwoCreaturesFromYourGraveyardToYourHandEffect());
        }
    }
}
