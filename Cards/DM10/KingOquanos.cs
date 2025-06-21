namespace Cards.DM10
{
    class KingOquanos : Engine.Creature
    {
        public KingOquanos() : base("King Oquanos", 8, 2000, Interfaces.Race.Leviathan, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ContinuousEffects.GetsPowerForEachTappedCardInYourOpponentsManaZoneEffect(1000), new ContinuousEffects.PoweredDoubleBreaker());
        }
    }
}
