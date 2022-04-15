﻿namespace Cards.Cards.DM06
{
    class KanesillTheExplorer : Creature
    {
        public KanesillTheExplorer() : base("Kanesill, the Explorer", 3, 4000, Engine.Subtype.Gladiator, Common.Civilization.Light)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
