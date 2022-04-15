namespace Cards.Cards.DM07
{
    class PoppleFlowerpetalDancer : Creature
    {
        public PoppleFlowerpetalDancer() : base("Popple, Flowerpetal Dancer", 4, 2000, Engine.Subtype.SnowFaerie, Engine.Civilization.Nature)
        {
            AddTapAbility(new OneShotEffects.PutTopCardsOfDeckIntoManaZoneEffect(1));
        }
    }
}
