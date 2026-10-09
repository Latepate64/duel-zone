using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;
using ContinuousEffects.CannotAttack;

namespace Cards.DM12;

public sealed class TropicCrawler : Creature
{
    public TropicCrawler() : base("Tropic Crawler", 4, 3000, Race.EarthEater, Civilization.Water)
    {
        AddAbilities(new BlockerAbility());
        AddTriggeredAbility(new WheneverThisCreatureBlocksAbility(new TropicCrawlerEffect()));
        AddStaticAbilities(new ThisCreatureCannotAttackEffect());
    }
}
