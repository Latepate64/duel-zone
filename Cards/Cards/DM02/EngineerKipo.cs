namespace Cards.Cards.DM02
{
    class EngineerKipo : Creature
    {
        public EngineerKipo() : base("Engineer Kipo", 2, 2000, Engine.Subtype.Xenoparts, Engine.Civilization.Fire)
        {
            AddWhenThisCreatureIsDestroyedAbility(new OneShotEffects.MutualManaSacrificeEffect(1));
        }
    }
}
