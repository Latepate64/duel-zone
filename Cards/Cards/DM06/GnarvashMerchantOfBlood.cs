﻿using Common;

namespace Cards.Cards.DM06
{
    class GnarvashMerchantOfBlood : Creature
    {
        public GnarvashMerchantOfBlood() : base("Gnarvash, Merchant of Blood", 6, 8000, Subtype.DemonCommand, Civilization.Darkness)
        {
            AddAbilities(new StaticAbilities.DoubleBreakerAbility(), new TriggeredAbilities.AtTheEndOfYourTurnIfThisIsYourOnlyCreatureInTheBattleZoneDestroyItAbility());
        }
    }
}