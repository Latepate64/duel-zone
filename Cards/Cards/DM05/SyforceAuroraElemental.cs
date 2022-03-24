﻿using Common;

namespace Cards.Cards.DM05
{
    class SyforceAuroraElemental : Creature
    {
        public SyforceAuroraElemental() : base("Syforce, Aurora Elemental", 7, 7000, Subtype.AngelCommand, Civilization.Light)
        {
            AddAbilities(new StaticAbilities.BlockerAbility(), new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.ManaSpellRecoveryEffect(false)), new StaticAbilities.DoubleBreakerAbility());
        }
    }
}