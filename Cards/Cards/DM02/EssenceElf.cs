﻿using Common;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class EssenceElf : Creature
    {
        public EssenceElf() : base("Essence Elf", 2, 1000, Subtype.TreeFolk, Civilization.Nature)
        {
            AddAbilities(new EssenceElfAbility());
        }
    }

    class EssenceElfAbility : StaticAbility
    {
        public EssenceElfAbility() : base(new EssenceElfEffect())
        {
        }
    }

    class EssenceElfEffect : Engine.ContinuousEffects.CostModifyingEffect
    {
        public EssenceElfEffect() : base(-1, new CardFilters.OwnersHandSpellFilter())
        {
        }

        public override string ToString()
        {
            return "Your spells each cost 1 less to cast. They can't cost less than 1.";
        }
    }
}
