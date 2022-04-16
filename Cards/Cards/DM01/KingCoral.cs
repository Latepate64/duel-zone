namespace Cards.Cards.DM01
{
    class KingCoral : Creature
    {
        public KingCoral() : base("King Coral", 3, 1000, Engine.Race.Leviathan, Engine.Civilization.Water)
        {
            AddBlockerAbility();
        }
    }
}
