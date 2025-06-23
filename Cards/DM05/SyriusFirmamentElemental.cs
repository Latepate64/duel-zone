using ContinuousEffects;

namespace Cards.DM05
{
    sealed class SyriusFirmamentElemental : Creature
    {
        public SyriusFirmamentElemental() : base("Syrius, Firmament Elemental", 11, 12000, Interfaces.Race.AngelCommand, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new TripleBreakerEffect());
        }
    }
}
