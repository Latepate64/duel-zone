using TriggeredAbilities;
using ContinuousEffects;
using Interfaces;

namespace Cards.DM09
{
    sealed class KelpCandle : Creature
    {
        public KelpCandle() : base("Kelp Candle", 2, 1000, Race.CyberVirus, Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddTriggeredAbility(new WheneverThisCreatureBlocksAbility(new OneShotEffects.LookAtTheTopCardsOfYourDeckTakeOnePutRestOnBottomEffect()));
        }
    }
}
