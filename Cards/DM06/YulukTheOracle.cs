using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM06
{
    sealed class YulukTheOracle : Creature
    {
        public YulukTheOracle() : base("Yuluk, the Oracle", 1, 2500, Race.LightBringer, Civilization.Light)
        {
            AddStaticAbilities(new YouCanSummonThisCreatureOnlyIfYouHaveCastSpellThisTurnEffect());
        }
    }
}
