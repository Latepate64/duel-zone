namespace Cards.Cards.DM10
{
    class KaratePotato : Creature
    {
        public KaratePotato() : base("Karate Potato", 4, 1000, Engine.Race.WildVeggies, Engine.Civilization.Nature)
        {
            AddShieldTrigger();
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect(2));
        }
    }
}
