namespace Cards.Cards.DM05
{
    class SplitHeadHydroturtleQ : Creature
    {
        public SplitHeadHydroturtleQ() : base("Split-Head Hydroturtle Q", 5, 2000, Engine.Subtype.Survivor, Engine.Subtype.GelFish, Engine.Civilization.Water)
        {
            AddSurvivorAbility(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayDrawCardsEffect(1)));
        }
    }
}
