using Common;

namespace Cards.Cards.DM06
{
    class CrystalJouster : EvolutionCreature
    {
        public CrystalJouster() : base("Crystal Jouster", 7, 7000, Subtype.LiquidPeople, Civilization.Water)
        {
            AddAbilities(new StaticAbilities.DoubleBreakerAbility(), new StaticAbilities.WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility());
        }
    }
}
