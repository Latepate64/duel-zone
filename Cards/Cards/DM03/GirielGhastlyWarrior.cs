namespace Cards.Cards.DM03
{
    class GirielGhastlyWarrior : Creature
    {
        public GirielGhastlyWarrior() : base("Giriel, Ghastly Warrior", 8, 11000, Engine.Race.DemonCommand, Engine.Civilization.Darkness)
        {
            AddDoubleBreakerAbility();
        }
    }
}
