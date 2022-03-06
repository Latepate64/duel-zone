using Cards.StaticAbilities;

namespace Cards.Cards.DM06
{
    class HazardCrawler : Creature
    {
        public HazardCrawler() : base("Hazard Crawler", 5, 6000, Common.Subtype.EarthEater, Common.Civilization.Water)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
