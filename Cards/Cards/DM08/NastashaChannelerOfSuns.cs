using Cards.ContinuousEffects;
using Engine;

namespace Cards.Cards.DM08
{
    class NastashaChannelerOfSuns : Creature
    {
        public NastashaChannelerOfSuns() : base("Nastasha, Channeler of Suns", 7, 6000, Race.MechaDelSol, Civilization.Light)
        {
            AddDoubleBreakerAbility();
            AddStaticAbilities(new WhenOneOfYourShieldsWouldBeBrokenYouMayDestroyThisCreatureInsteadEffect());
        }
    }
}
