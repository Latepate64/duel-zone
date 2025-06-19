using Cards.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class ZagaanKnightOfDarkness : Engine.Creature
    {
        public ZagaanKnightOfDarkness() : base("Zagaan, Knight of Darkness", 6, 7000, Engine.Race.DemonCommand, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
