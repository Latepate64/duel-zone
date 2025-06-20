using Abilities.Triggered;
using ContinuousEffects;

namespace Cards.Cards.DM05
{
    class LaByleSeekerOfTheWinds : Engine.Creature
    {
        public LaByleSeekerOfTheWinds() : base("La Byle, Seeker of the Winds", 7, 5000, Engine.Race.MechaThunder, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new WheneverThisCreatureBlocksAbility(new OneShotEffects.UntapItAfterItBattlesEffect()));
        }
    }
}
