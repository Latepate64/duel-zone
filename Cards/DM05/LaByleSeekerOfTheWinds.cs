using Abilities.Static;
using TriggeredAbilities;

namespace Cards.DM05
{
    sealed class LaByleSeekerOfTheWinds : Creature
    {
        public LaByleSeekerOfTheWinds() : base("La Byle, Seeker of the Winds", 7, 5000, Interfaces.Race.MechaThunder, Interfaces.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddTriggeredAbility(new WheneverThisCreatureBlocksAbility(new OneShotEffects.UntapItAfterItBattlesEffect()));
        }
    }
}
