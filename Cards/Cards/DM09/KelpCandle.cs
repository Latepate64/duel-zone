using Engine;

namespace Cards.Cards.DM09
{
    class KelpCandle : Creature
    {
        public KelpCandle() : base("Kelp Candle", 2, 1000, Race.CyberVirus, Civilization.Water)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackAbility();
            AddTriggeredAbility(new TriggeredAbilities.WheneverThisCreatureBlocksAbility(new OneShotEffects.LookAtTheTopCardsOfYourDeckTakeOnePutRestOnBottomEffect()));
        }
    }
}
