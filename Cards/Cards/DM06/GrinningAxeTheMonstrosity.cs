namespace Cards.Cards.DM06
{
    class GrinningAxeTheMonstrosity : Creature
    {
        public GrinningAxeTheMonstrosity() : base("Grinning Axe, the Monstrosity", 3, 1000, Engine.Race.DevilMask, Engine.Civilization.Darkness)
        {
            AddSlayerAbility();
        }
    }
}
