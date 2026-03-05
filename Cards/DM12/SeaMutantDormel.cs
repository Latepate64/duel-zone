namespace Cards.DM12
{
    sealed class SeaMutantDormel : Creature
    {
        public SeaMutantDormel() : base("Sea Mutant Dormel", 3, 4000, [Interfaces.Race.Merfolk, Interfaces.Race.Hedrian], Interfaces.Civilization.Water, Interfaces.Civilization.Darkness)
        {
        }
    }
}
