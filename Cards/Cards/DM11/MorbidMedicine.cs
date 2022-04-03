using Common;

namespace Cards.Cards.DM11
{
    class MorbidMedicine : Spell
    {
        public MorbidMedicine() : base("Morbid Medicine", 4, Civilization.Darkness)
        {
            AddSpellAbilities(new OneShotEffects.ReturnUpToCreaturesFromYourGraveyardToYourHandEffect(2));
        }
    }
}
