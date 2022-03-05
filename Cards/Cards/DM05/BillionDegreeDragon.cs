using Common;

namespace Cards.Cards.DM05
{
    class BillionDegreeDragon : Creature
    {
        public BillionDegreeDragon() : base("Billion-Degree Dragon", 10, Civilization.Fire, 15000, Subtype.ArmoredDragon)
        {
            Abilities.Add(new StaticAbilities.TripleBreakerAbility());
        }
    }
}
