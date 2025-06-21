using ContinuousEffects;

namespace Cards.DM01
{
    class ZagaanKnightOfDarkness : Engine.Creature
    {
        public ZagaanKnightOfDarkness() : base("Zagaan, Knight of Darkness", 6, 7000, Interfaces.Race.DemonCommand, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
