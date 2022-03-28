using Common;

namespace Cards.Cards.DM07
{
    class PoppleFlowerpetalDancer : Creature
    {
        public PoppleFlowerpetalDancer() : base("Popple, Flowerpetal Dancer", 4, 2000, Subtype.SnowFaerie, Civilization.Nature)
        {
            AddTapAbility(new OneShotEffects.PutTopCardsOfDeckIntoManaZoneEffect(1));
        }
    }
}
