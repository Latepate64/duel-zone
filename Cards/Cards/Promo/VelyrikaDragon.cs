namespace Cards.Cards.Promo
{
    class VelyrikaDragon : Creature
    {
        public VelyrikaDragon() : base("Velyrika Dragon", 7, 7000, Engine.Race.ArmoredDragon, Engine.Civilization.Fire)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.SearchRaceCreatureEffect(Engine.Race.ArmoredDragon));
            AddDoubleBreakerAbility();
        }
    }
}
