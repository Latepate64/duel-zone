using Cards.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class CrystalJouster : EvolutionCreature
    {
        public CrystalJouster() : base("Crystal Jouster", 7, 7000, Engine.Subtype.LiquidPeople, Engine.Civilization.Water)
        {
            AddDoubleBreakerAbility();
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect());
        }
    }
}
