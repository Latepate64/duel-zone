using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM05
{
    class SyriusFirmamentElemental : Engine.Creature
    {
        public SyriusFirmamentElemental() : base("Syrius, Firmament Elemental", 11, 12000, Engine.Race.AngelCommand, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new TripleBreakerEffect());
        }
    }
}
