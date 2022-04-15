namespace Cards.Cards.DM01
{
    class AquaHulcus : Creature
    {
        public AquaHulcus() : base("Aqua Hulcus", 3, 2000, Engine.Subtype.LiquidPeople, Engine.Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayDrawCardsEffect(1));
        }
    }
}
