using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM05
{
    class SplitHeadHydroturtleQ : Engine.Creature
    {
        public SplitHeadHydroturtleQ() : base("Split-Head Hydroturtle Q", 5, 2000, [Engine.Race.Survivor, Engine.Race.GelFish], Engine.Civilization.Water)
        {
            AddStaticAbilities(new SurvivorEffect(new WheneverThisCreatureAttacksAbility(
                new OneShotEffects.YouMayDrawCardEffect())));
        }
    }
}
