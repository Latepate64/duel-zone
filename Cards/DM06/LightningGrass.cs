namespace Cards.DM06
{
    sealed class LightningGrass : Engine.Creature
    {
        public LightningGrass() : base("Lightning Grass", 3, 3000, Interfaces.Race.StarlightTree, Interfaces.Civilization.Light)
        {
        }
    }
}
