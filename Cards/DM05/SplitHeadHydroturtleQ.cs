using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM05;

sealed class SplitHeadHydroturtleQ : Creature
{
    public SplitHeadHydroturtleQ() : base("Split-Head Hydroturtle Q", 5, 2000, [Race.Survivor, Race.GelFish], Civilization.Water)
    {
        AddStaticAbilities(
            new SurvivorEffect(
                new WheneverThisCreatureAttacksAbility(
                    new YouMayDrawCardsEffect(1))));
    }
}