using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM05
{
    class LaByleSeekerOfTheWinds : Engine.Creature
    {
        public LaByleSeekerOfTheWinds() : base("La Byle, Seeker of the Winds", 7, 5000, Interfaces.Race.MechaThunder, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new WheneverThisCreatureBlocksAbility(new OneShotEffects.UntapItAfterItBattlesEffect()));
        }
    }
}
