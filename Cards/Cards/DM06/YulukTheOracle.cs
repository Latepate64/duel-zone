using Cards.ContinuousEffects;
using Engine;

namespace Cards.Cards.DM06
{
    class YulukTheOracle : Creature
    {
        public YulukTheOracle() : base("Yuluk, the Oracle", 1, 2500, Race.LightBringer, Civilization.Light)
        {
            AddStaticAbilities(new YouCanSummonThisCreatureOnlyIfYouHaveCastSpellThisTurnEffect());
        }
    }
}
