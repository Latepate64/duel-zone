using Abilities.Static;
using ContinuousEffects.Replacement;

namespace Cards.DM06
{
    sealed class CrystalJouster : EvolutionCreature
    {
        public CrystalJouster() : base("Crystal Jouster", 7, 7000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
            AddAbilities(new DoubleBreakerAbility());
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect());
        }
    }
}
