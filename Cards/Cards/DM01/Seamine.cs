namespace Cards.Cards.DM01
{
    class Seamine : Creature
    {
        public Seamine() : base("Seamine", 6, 4000, Engine.Race.Fish, Engine.Civilization.Water)
        {
            AddBlockerAbility();
        }
    }
}
