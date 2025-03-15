namespace Cards.Cards.DM10
{
    public class TidePatroller : Creature
    {
        public TidePatroller() : base("Tide Patroller", 4, 2000, Engine.Race.Merfolk, Engine.Civilization.Water)
        {
            AddBlockerAbility();
        }
    }
}
