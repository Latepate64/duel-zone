namespace Cards.Cards.DM06
{
    class CantankerousGiant : Creature
    {
        public CantankerousGiant() : base("Cantankerous Giant", 7, 8000, Engine.Race.Giant, Engine.Civilization.Nature)
        {
            AddDoubleBreakerAbility();
        }
    }
}
