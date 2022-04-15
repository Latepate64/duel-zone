namespace Cards.Cards.DM10
{
    class BuoyantBlowfish : Creature
    {
        public BuoyantBlowfish() : base("Buoyant Blowfish", 5, 1000, Engine.Subtype.GelFish, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ContinuousEffects.GetsPowerForEachTappedCardInYourOpponentsManaZoneEffect(1000));
        }
    }
}
