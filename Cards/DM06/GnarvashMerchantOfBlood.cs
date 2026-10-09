using Abilities.Static;
using TriggeredAbilities;

namespace Cards.DM06
{
    sealed class GnarvashMerchantOfBlood : Creature
    {
        public GnarvashMerchantOfBlood() : base("Gnarvash, Merchant of Blood", 6, 8000, Interfaces.Race.DemonCommand, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new DoubleBreakerAbility());
            AddTriggeredAbility(new AtTheEndOfYourTurnIfThisIsYourOnlyCreatureInTheBattleZoneDestroyItAbility(
                new OneShotEffects.DestroyThisCreatureEffect()));
        }
    }
}