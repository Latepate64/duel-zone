using Common;

namespace Cards.Cards.DM02
{
    class LeapingTornadoHorn : Creature
    {
        public LeapingTornadoHorn() : base("Leaping Tornado Horn", 3, 2000, Subtype.HornedBeast, Civilization.Nature)
        {
            AddAbilities(new StaticAbilities.LeapingTornadoHornAbility());
        }
    }
}
