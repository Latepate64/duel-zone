﻿using Common;

namespace Cards.Cards.DM10
{
    public class GontaTheWarriorSavage : Creature
    {
        public GontaTheWarriorSavage() : base("Gonta, the Warrior Savage", 2, 4000)
        {
            AddCivilizations(Civilization.Fire, Civilization.Nature);
            AddSubtypes(Subtype.Human, Subtype.BeastFolk);
        }
    }
}
