using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM09;

public sealed class StormWranglerTheFurious : EvolutionCreature
{
    public StormWranglerTheFurious() : base("Storm Wrangler, the Furious", 4,
        5000, Race.BeastFolk, Civilization.Nature)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new StormWranglerEffect(
                    new MultiFilter(
                        new UntappedCreatureFilter(),
                        new BlockerFilter()
                    )
                )));
        AddTriggeredAbility(
            new WheneverThisCreatureBecomesBlockedAbility(
                new ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(3000)));
    }
}
