﻿namespace Cards.Cards.DM12
{
    class Gigaslug : Creature
    {
        public Gigaslug() : base("Gigaslug", 3, 1000, Engine.Subtype.Chimera, Engine.Civilization.Darkness)
        {
            AddBlockerAbility();
            AddSlayerAbility();
            AddThisCreatureCannotAttackAbility();
        }
    }
}
