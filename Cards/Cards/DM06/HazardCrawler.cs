using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM06
{
    public class HazardCrawler : Creature
    {
        public HazardCrawler() : base("Hazard Crawler", 5, Civilization.Water, 6000, Subtype.EarthEater)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
