using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM06
{
    class GnarvashMerchantOfBlood : Engine.Creature
    {
        public GnarvashMerchantOfBlood() : base("Gnarvash, Merchant of Blood", 6, 8000, Engine.Race.DemonCommand, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
            AddTriggeredAbility(new AtTheEndOfYourTurnIfThisIsYourOnlyCreatureInTheBattleZoneDestroyItAbility(
                new OneShotEffects.DestroyThisCreatureEffect()));
        }
    }
}