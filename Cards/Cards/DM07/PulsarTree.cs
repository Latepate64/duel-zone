using Cards.ContinuousEffects;
using Engine;

namespace Cards.Cards.DM07
{
    class PulsarTree : Creature
    {
        public PulsarTree() : base("Pulsar Tree", 5, 1000, Race.StarlightTree, Civilization.Light)
        {
            AddStaticAbilities(new WhenOneOfYourShieldsWouldBeBrokenYouMayDestroyThisCreatureInsteadEffect());
        }
    }
}
