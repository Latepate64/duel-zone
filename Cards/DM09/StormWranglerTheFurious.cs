using TriggeredAbilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

public sealed class StormWranglerTheFurious : EvolutionCreature
{
    public StormWranglerTheFurious() : base("Storm Wrangler, the Furious", 4, 5000, Race.BeastFolk, Civilization.Nature)
    {
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new StormWranglerEffect()));
        AddTriggeredAbility(new WheneverThisCreatureBecomesBlockedAbility(
            new OneShotEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(3000)));
    }
}
