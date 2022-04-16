namespace Cards.Cards.DM01
{
    class Gigagiele : Creature
    {
        public Gigagiele() : base("Gigagiele", 5, 3000, Engine.Race.Chimera, Engine.Civilization.Darkness)
        {
            AddSlayerAbility();
        }
    }
}
