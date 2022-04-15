namespace Cards.Cards.DM10
{
    class TidePatroller : Creature
    {
        public TidePatroller() : base("Tide Patroller", 4, 2000, Engine.Subtype.Merfolk, Common.Civilization.Water)
        {
            AddBlockerAbility();
        }
    }
}
