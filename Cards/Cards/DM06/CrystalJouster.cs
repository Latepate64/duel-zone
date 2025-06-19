using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM06
{
    class CrystalJouster : EvolutionCreature
    {
        public CrystalJouster() : base("Crystal Jouster", 7, 7000, Engine.Race.LiquidPeople, Engine.Civilization.Water)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect());
        }
    }
}
