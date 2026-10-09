using TriggeredAbilities;
using Interfaces;
using Abilities.Static;
using ContinuousEffects.CannotAttack;

namespace Cards.DM09
{
    sealed class KelpCandle : Creature
    {
        public KelpCandle() : base("Kelp Candle", 2, 1000, Race.CyberVirus, Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddTriggeredAbility(new WheneverThisCreatureBlocksAbility(new OneShotEffects.LookAtTheTopCardsOfYourDeckTakeOnePutRestOnBottomEffect()));
        }
    }
}
