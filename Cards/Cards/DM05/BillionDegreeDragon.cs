using Common;

namespace Cards.Cards.DM05
{
    class BillionDegreeDragon : Creature
    {
        public BillionDegreeDragon() : base("Billion-Degree Dragon", 10, 15000, Engine.Subtype.ArmoredDragon, Civilization.Fire)
        {
            AddTripleBreakerAbility();
        }
    }
}
