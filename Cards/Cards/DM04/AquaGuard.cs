﻿using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM04
{
    class AquaGuard : Creature
    {
        public AquaGuard() : base("Aqua Guard", 1, 2000, Subtype.LiquidPeople, Civilization.Water)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
