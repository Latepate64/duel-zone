using TriggeredAbilities;
using ContinuousEffects;
using Engine;

namespace Cards.Cards.DM09
{
    class KelpCandle : Creature
    {
        public KelpCandle() : base("Kelp Candle", 2, 1000, Race.CyberVirus, Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddTriggeredAbility(new WheneverThisCreatureBlocksAbility(new OneShotEffects.LookAtTheTopCardsOfYourDeckTakeOnePutRestOnBottomEffect()));
        }
    }
}
