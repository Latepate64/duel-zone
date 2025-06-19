using Cards.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class GnarvashMerchantOfBlood : Creature
    {
        public GnarvashMerchantOfBlood() : base("Gnarvash, Merchant of Blood", 6, 8000, Engine.Race.DemonCommand, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
            AddTriggeredAbility(new TriggeredAbilities.AtTheEndOfYourTurnIfThisIsYourOnlyCreatureInTheBattleZoneDestroyItAbility());
        }
    }
}