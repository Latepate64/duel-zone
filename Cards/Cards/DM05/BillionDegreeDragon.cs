using Common;

namespace Cards.Cards.DM05
{
    class BillionDegreeDragon : Creature
    {
        public BillionDegreeDragon() : base("Billion-Degree Dragon", 10, 15000, Subtype.ArmoredDragon, Civilization.Fire)
        {
            Abilities.Add(new StaticAbilities.TripleBreakerAbility());
        }
    }
}
