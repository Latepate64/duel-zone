using ContinuousEffects;

namespace Cards.DM06
{
    sealed class GrinningAxeTheMonstrosity : Engine.Creature
    {
        public GrinningAxeTheMonstrosity() : base("Grinning Axe, the Monstrosity", 3, 1000, Interfaces.Race.DevilMask, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
        }
    }
}
