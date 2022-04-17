namespace Cards.Cards.DM11
{
    class MelodicHunter : Creature
    {
        public MelodicHunter() : base("Melodic Hunter", 5, 3000, Engine.Race.Merfolk, Engine.Civilization.Water)
        {
            AddBlockerAbility();
        }
    }
}
