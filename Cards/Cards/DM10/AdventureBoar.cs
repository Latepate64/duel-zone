namespace Cards.Cards.DM10
{
    public class AdventureBoar : Creature
    {
        public AdventureBoar() : base("Adventure Boar", 2, 1000, Engine.Race.BeastFolk, Engine.Civilization.Nature)
        {
            AddPowerAttackerAbility(2000);
        }
    }
}
