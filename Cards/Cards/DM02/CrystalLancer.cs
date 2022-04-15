namespace Cards.Cards.DM02
{
    class CrystalLancer : EvolutionCreature
    {
        public CrystalLancer() : base("Crystal Lancer", 6, 8000, Engine.Subtype.LiquidPeople, Engine.Civilization.Water)
        {
            AddThisCreatureCannotBeBlockedAbility();
            AddDoubleBreakerAbility();
        }
    }
}
