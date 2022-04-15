﻿namespace Cards.Cards.DM01
{
    class EmeraldGrass : Creature
    {
        public EmeraldGrass() : base("Emerald Grass", 2, 3000, Engine.Subtype.StarlightTree, Common.Civilization.Light)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
