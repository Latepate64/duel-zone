using Cards.ContinuousEffects;
using Engine;

namespace Cards.Cards.DM06
{
    class GarielElementalOfSunbeams : Creature
    {
        public GarielElementalOfSunbeams() : base("Gariel, Elemental of Sunbeams", 5, 7500, Race.AngelCommand, Civilization.Light)
        {
            AddStaticAbilities(new YouCanSummonThisCreatureOnlyIfYouHaveCastSpellThisTurnEffect());
            AddDoubleBreakerAbility();
        }
    }
}
