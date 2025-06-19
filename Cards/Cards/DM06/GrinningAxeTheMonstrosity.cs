using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM06
{
    class GrinningAxeTheMonstrosity : Engine.Creature
    {
        public GrinningAxeTheMonstrosity() : base("Grinning Axe, the Monstrosity", 3, 1000, Engine.Race.DevilMask, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
        }
    }
}
