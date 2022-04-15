using Common;

namespace Cards.Cards.DM06
{
    class CantankerousGiant : Creature
    {
        public CantankerousGiant() : base("Cantankerous Giant", 7, 8000, Engine.Subtype.Giant, Civilization.Nature)
        {
            AddDoubleBreakerAbility();
        }
    }
}
