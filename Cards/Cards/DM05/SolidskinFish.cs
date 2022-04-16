namespace Cards.Cards.DM05
{
    class SolidskinFish : Creature
    {
        public SolidskinFish() : base("Solidskin Fish", 3, 3000, Engine.Race.Fish, Engine.Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnCardFromYourManaZoneToYourHandEffect());
        }
    }
}
