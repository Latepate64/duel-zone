using Common;

namespace Cards.Cards.DM05
{
    class SplitHeadHydroturtleQ : Creature
    {
        public SplitHeadHydroturtleQ() : base("Split-Head Hydroturtle Q", 5, 2000, Civilization.Water)
        {
            AddSubtypes(Subtype.Survivor, Subtype.GelFish);
            AddSurvivorAbility(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayDrawCardsEffect(1)));
        }
    }
}
