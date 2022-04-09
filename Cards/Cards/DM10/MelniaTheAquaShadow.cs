﻿using Common;

namespace Cards.Cards.DM10
{
    class MelniaTheAquaShadow : Creature
    {
        public MelniaTheAquaShadow() : base("Melnia, the Aqua Shadow", 2, 1000, Subtype.LiquidPeople, Subtype.Ghost, Civilization.Water, Civilization.Darkness)
        {
            AddThisCreatureCannotBeBlockedAbility();
            AddSlayerAbility();
        }
    }
}
