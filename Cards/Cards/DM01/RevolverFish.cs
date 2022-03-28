﻿namespace Cards.Cards.DM01
{
    class RevolverFish : Creature
    {
        public RevolverFish() : base("Revolver Fish", 4, 5000, Common.Subtype.GelFish, Common.Civilization.Water)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackAbility();
        }
    }
}
