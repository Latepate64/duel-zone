using Common;

namespace Cards.Cards.Promo
{
    class VelyrikaDragon : Creature
    {
        public VelyrikaDragon() : base("Velyrika Dragon", 7, 7000, Subtype.ArmoredDragon, Civilization.Fire)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.SearchSubtypeCreatureEffect(Subtype.ArmoredDragon));
            AddDoubleBreakerAbility();
        }
    }
}
