namespace Cards.DM10
{
    class BuoyantBlowfish : Engine.Creature
    {
        public BuoyantBlowfish() : base("Buoyant Blowfish", 5, 1000, Interfaces.Race.GelFish, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ContinuousEffects.GetsPowerForEachTappedCardInYourOpponentsManaZoneEffect(1000));
        }
    }
}
