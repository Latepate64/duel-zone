namespace Cards.Cards.DM02
{
    class AmberPiercer : Creature
    {
        public AmberPiercer() : base("Amber Piercer", 4, 2000, Engine.Race.BrainJacker, Engine.Civilization.Darkness)
        {
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.ReturnUpToCreaturesFromYourGraveyardToYourHandEffect(1));
        }
    }
}