﻿namespace Cards.Cards.DM06
{
    class GnarvashMerchantOfBlood : Creature
    {
        public GnarvashMerchantOfBlood() : base("Gnarvash, Merchant of Blood", 6, 8000, Engine.Subtype.DemonCommand, Engine.Civilization.Darkness)
        {
            AddDoubleBreakerAbility();
            AddTriggeredAbility(new TriggeredAbilities.AtTheEndOfYourTurnIfThisIsYourOnlyCreatureInTheBattleZoneDestroyItAbility());
        }
    }
}