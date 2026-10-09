using Abilities.Static;
using ContinuousEffects.CannotUseCard;
using Interfaces;

namespace Cards.DM06
{
    sealed class GarielElementalOfSunbeams : Creature
    {
        public GarielElementalOfSunbeams() : base("Gariel, Elemental of Sunbeams", 5, 7500, Race.AngelCommand, Civilization.Light)
        {
            AddStaticAbilities(new YouCanSummonThisCreatureOnlyIfYouHaveCastSpellThisTurnEffect());
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
