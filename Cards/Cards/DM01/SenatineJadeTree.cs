﻿using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class SenatineJadeTree : Creature
    {
        public SenatineJadeTree() : base("Senatine Jade Tree", 3, 4000, Common.Subtype.StarlightTree, Common.Civilization.Light)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
