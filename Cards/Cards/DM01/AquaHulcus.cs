namespace Cards.Cards.DM01
{
    class AquaHulcus : Creature
    {
        public AquaHulcus() : base("Aqua Hulcus", 3, 2000, Common.Subtype.LiquidPeople, Common.Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayDrawCardsEffect(1));
        }
    }
}
