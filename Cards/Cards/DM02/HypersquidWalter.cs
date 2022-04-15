namespace Cards.Cards.DM02
{
    class HypersquidWalter : Creature
    {
        public HypersquidWalter() : base("Hypersquid Walter", 3, 1000, Engine.Subtype.CyberLord, Common.Civilization.Water)
        {
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayDrawCardsEffect(1));
        }
    }
}
