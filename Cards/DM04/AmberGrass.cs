namespace Cards.DM04
{
    class AmberGrass : Engine.Creature
    {
        public AmberGrass() : base("Amber Grass", 4, 3000, Engine.Race.StarlightTree, Engine.Civilization.Light)
        {
            AddShieldTrigger();
        }
    }
}
