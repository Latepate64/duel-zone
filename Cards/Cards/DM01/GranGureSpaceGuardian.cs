﻿namespace Cards.Cards.DM01
{
    class GranGureSpaceGuardian : Creature
    {
        public GranGureSpaceGuardian() : base("Gran Gure, Space Guardian", 6, 9000, Engine.Subtype.Guardian, Common.Civilization.Light)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
