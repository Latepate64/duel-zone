using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM02
{
    class LeapingTornadoHorn : Creature
    {
        public LeapingTornadoHorn() : base("Leaping Tornado Horn", 3, 2000, Engine.Subtype.HornedBeast, Civilization.Nature)
        {
            AddStaticAbilities(new LeapingTornadoHornEffect());
        }
    }
}
