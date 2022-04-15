namespace Cards.Cards.DM12
{
    class WilyCarpenter : Creature
    {
        public WilyCarpenter() : base("Wily Carpenter", 3, 1000, Engine.Subtype.Merfolk, Engine.Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.DrawThenDiscardEffect(2));
        }
    }
}
