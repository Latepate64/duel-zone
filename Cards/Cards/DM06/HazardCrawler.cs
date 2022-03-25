using Cards.StaticAbilities;

namespace Cards.Cards.DM06
{
    class HazardCrawler : Creature
    {
        public HazardCrawler() : base("Hazard Crawler", 5, 6000, Common.Subtype.EarthEater, Common.Civilization.Water)
        {
            AddAbilities(new BlockerAbility(), new ThisCreatureCannotAttackCreaturesAbility(), new ThisCreatureCannotAttackPlayersAbility());
        }
    }
}
