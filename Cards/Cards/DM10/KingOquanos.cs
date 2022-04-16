namespace Cards.Cards.DM10
{
    class KingOquanos : Creature
    {
        public KingOquanos() : base("King Oquanos", 8, 2000, Engine.Race.Leviathan, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ContinuousEffects.GetsPowerForEachTappedCardInYourOpponentsManaZoneEffect(1000), new ContinuousEffects.PoweredDoubleBreaker());
        }
    }
}
