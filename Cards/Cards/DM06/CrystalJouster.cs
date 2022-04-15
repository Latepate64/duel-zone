using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM06
{
    class CrystalJouster : EvolutionCreature
    {
        public CrystalJouster() : base("Crystal Jouster", 7, 7000, Engine.Subtype.LiquidPeople, Civilization.Water)
        {
            AddDoubleBreakerAbility();
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect());
        }
    }
}
