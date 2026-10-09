using Abilities.Static;
using ContinuousEffects.Replacement;
using Interfaces;

namespace Cards.DM08
{
    sealed class NastashaChannelerOfSuns : Creature
    {
        public NastashaChannelerOfSuns() : base("Nastasha, Channeler of Suns", 7, 6000, Race.MechaDelSol, Civilization.Light)
        {
            AddAbilities(new DoubleBreakerAbility());
            AddStaticAbilities(new WhenOneOfYourShieldsWouldBeBrokenYouMayDestroyThisCreatureInsteadEffect());
        }
    }
}
