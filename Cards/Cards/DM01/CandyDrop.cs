namespace Cards.Cards.DM01
{
    class CandyDrop : Creature
    {
        public CandyDrop() : base("Candy Drop", 3, 1000, Engine.Subtype.CyberVirus, Common.Civilization.Water)
        {
            AddThisCreatureCannotBeBlockedAbility();
        }
    }
}
