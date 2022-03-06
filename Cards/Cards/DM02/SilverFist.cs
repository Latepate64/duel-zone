﻿namespace Cards.Cards.DM02
{
    class SilverFist : Creature
    {
        public SilverFist() : base("Silver Fist", 4, 3000, Common.Subtype.BeastFolk, Common.Civilization.Nature)
        {
            Abilities.Add(new StaticAbilities.PowerAttackerAbility(2000));
        }
    }
}
