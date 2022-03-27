using Common;
using Engine.Abilities;
using Engine.ContinuousEffects;

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

    class EssenceElfEffect : CostModifyingEffect
    {
        public EssenceElfEffect() : base(-1, new CardFilters.OwnersHandSpellFilter(), new Durations.Indefinite())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new EssenceElfEffect();
        }

        public override string ToString()
        {
            return "Your spells each cost 1 less to cast. They can't cost less than 1.";
        }
    }
}
