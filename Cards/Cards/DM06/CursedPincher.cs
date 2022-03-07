﻿using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM06
{
    class CursedPincher : Creature
    {
        public CursedPincher() : base("Cursed Pincher", 4, 2000, Subtype.BrainJacker, Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility(), new SlayerAbility(), new CannotAttackCreaturesAbility(), new CannotAttackPlayersAbility());
        }
    }
}