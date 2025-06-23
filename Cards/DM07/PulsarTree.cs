using ContinuousEffects;
using Interfaces;

namespace Cards.DM07
{
    sealed class PulsarTree : Creature
    {
        public PulsarTree() : base("Pulsar Tree", 5, 1000, Race.StarlightTree, Civilization.Light)
        {
            AddStaticAbilities(new WhenOneOfYourShieldsWouldBeBrokenYouMayDestroyThisCreatureInsteadEffect());
        }
    }
}
