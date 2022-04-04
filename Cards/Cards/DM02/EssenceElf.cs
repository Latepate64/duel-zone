using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM02
{
    class EssenceElf : Creature
    {
        public EssenceElf() : base("Essence Elf", 2, 1000, Subtype.TreeFolk, Civilization.Nature)
        {
            AddStaticAbilities(new EssenceElfEffect());
        }
    }

    class EssenceElfEffect : ContinuousEffect, ICostModifyingEffect
    {
        public EssenceElfEffect() : base(new CardFilters.OwnersHandSpellFilter(), new Durations.Indefinite())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new EssenceElfEffect();
        }

        public int GetChange()
        {
            return -1;
        }

        public override string ToString()
        {
            return "Your spells each cost 1 less to cast. They can't cost less than 1.";
        }
    }
}
