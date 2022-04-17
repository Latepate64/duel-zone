namespace Cards.Cards.DM09
{
    class StallobTheLifequasher : Creature
    {
        public StallobTheLifequasher() : base("Stallob, the Lifequasher", 8, 6000, Engine.Race.DemonCommand, Engine.Civilization.Darkness)
        {
            AddDoubleBreakerAbility();
            AddWhenThisCreatureIsDestroyedAbility(new OneShotEffects.DestroyAllCreaturesEffect());
        }
    }
}
