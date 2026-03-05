using ContinuousEffects;

namespace Cards.DM02
{
    sealed class LadiaBaleTheInspirational : EvolutionCreature
    {
        public LadiaBaleTheInspirational() : base("Ladia Bale, the Inspirational", 6, 9500, Interfaces.Race.Guardian, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
