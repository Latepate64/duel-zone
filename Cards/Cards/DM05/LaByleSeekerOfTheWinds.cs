namespace Cards.Cards.DM05
{
    class LaByleSeekerOfTheWinds : Creature
    {
        public LaByleSeekerOfTheWinds() : base("La Byle, Seeker of the Winds", 7, 5000, Engine.Subtype.MechaThunder, Engine.Civilization.Light)
        {
            AddBlockerAbility();
            AddTriggeredAbility(new TriggeredAbilities.WheneverThisCreatureBlocksAbility(new OneShotEffects.UntapItAfterItBattlesEffect()));
        }
    }
}
