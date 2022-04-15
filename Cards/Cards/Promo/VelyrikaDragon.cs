namespace Cards.Cards.Promo
{
    class VelyrikaDragon : Creature
    {
        public VelyrikaDragon() : base("Velyrika Dragon", 7, 7000, Engine.Subtype.ArmoredDragon, Engine.Civilization.Fire)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.SearchSubtypeCreatureEffect(Engine.Subtype.ArmoredDragon));
            AddDoubleBreakerAbility();
        }
    }
}
