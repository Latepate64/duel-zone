﻿using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM07
{
    class Gigabuster : Creature
    {
        public Gigabuster() : base("Gigabuster", 5, 5000, Subtype.Chimera, Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility(), new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.ShieldRecoveryEffect(false)), new CannotAttackCreaturesAbility(), new CannotAttackPlayersAbility());
        }
    }
}