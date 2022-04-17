namespace Cards.Cards.DM01
{
    class FireSweeperBurningHellion : Creature
    {
        public FireSweeperBurningHellion() : base("Fire Sweeper Burning Hellion", 4, 3000, Engine.Race.Dragonoid, Engine.Civilization.Fire)
        {
            AddPowerAttackerAbility(2000);
        }
    }
}
