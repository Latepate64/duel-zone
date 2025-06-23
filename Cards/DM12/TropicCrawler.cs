using TriggeredAbilities;
using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM12;

public sealed class TropicCrawler : Creature
{
    public TropicCrawler() : base("Tropic Crawler", 4, 3000, Race.EarthEater, Civilization.Water)
    {
        AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        AddTriggeredAbility(new WheneverThisCreatureBlocksAbility(new TropicCrawlerEffect()));
        AddStaticAbilities(new ThisCreatureCannotAttackEffect());
    }
}
