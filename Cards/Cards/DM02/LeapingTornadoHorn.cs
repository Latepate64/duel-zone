using Cards.ContinuousEffects;

namespace Cards.Cards.DM02
{
    class LeapingTornadoHorn : Creature
    {
        public LeapingTornadoHorn() : base("Leaping Tornado Horn", 3, 2000, Engine.Race.HornedBeast, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new LeapingTornadoHornEffect());
        }
    }
}
