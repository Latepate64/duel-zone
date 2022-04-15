namespace Cards.Cards.DM06
{
    class HazardCrawler : Creature
    {
        public HazardCrawler() : base("Hazard Crawler", 5, 6000, Engine.Subtype.EarthEater, Engine.Civilization.Water)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackAbility();
        }
    }
}
