namespace Cards.Cards.DM03
{
    class Emeral : Creature
    {
        public Emeral() : base("Emeral", 2, 1000, Engine.Subtype.CyberLord, Common.Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.EmeralEffect());
        }
    }
}
