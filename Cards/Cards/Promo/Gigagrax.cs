namespace Cards.Cards.Promo
{
    class Gigagrax : Creature
    {
        public Gigagrax() : base("Gigagrax", 8, 5000, Engine.Subtype.Chimera, Engine.Civilization.Darkness)
        {
            AddWhenThisCreatureIsDestroyedAbility(new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesEffect());
        }
    }
}
