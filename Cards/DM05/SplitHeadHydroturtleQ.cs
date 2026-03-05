using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM05
{
    sealed class SplitHeadHydroturtleQ : Creature
    {
        public SplitHeadHydroturtleQ() : base("Split-Head Hydroturtle Q", 5, 2000, [Interfaces.Race.Survivor, Interfaces.Race.GelFish], Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new SurvivorEffect(new WheneverThisCreatureAttacksAbility(
                new OneShotEffects.YouMayDrawCardEffect())));
        }
    }
}
