namespace Cards.Cards.DM01
{
    class CandyDrop : Creature
    {
        public CandyDrop() : base("Candy Drop", 3, 1000, Engine.Race.CyberVirus, Engine.Civilization.Water)
        {
            AddThisCreatureCannotBeBlockedAbility();
        }
    }
}
