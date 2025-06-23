namespace Cards.DM10
{
    sealed class GontaTheWarriorSavage : Creature
    {
        public GontaTheWarriorSavage() : base("Gonta, the Warrior Savage", 2, 4000, [Interfaces.Race.Human, Interfaces.Race.BeastFolk], Interfaces.Civilization.Fire, Interfaces.Civilization.Nature)
        {
        }
    }
}
