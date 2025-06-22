namespace Cards.DM01
{
    sealed class ForestHornet : Engine.Creature
    {
        public ForestHornet() : base("Forest Hornet", 4, 4000, Interfaces.Race.GiantInsect, Interfaces.Civilization.Nature)
        {
        }
    }
}
