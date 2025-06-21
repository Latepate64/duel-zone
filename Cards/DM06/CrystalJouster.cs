using ContinuousEffects;

namespace Cards.DM06
{
    class CrystalJouster : EvolutionCreature
    {
        public CrystalJouster() : base("Crystal Jouster", 7, 7000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect());
        }
    }
}
