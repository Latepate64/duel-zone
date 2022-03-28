using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM02
{
    class ElfX : Creature
    {
        public ElfX() : base("Elf-X", 4, 2000, Subtype.TreeFolk, Civilization.Nature)
        {
            AddStaticAbilities(new ElfXEffect());
        }
    }

    class ElfXEffect : CostModifyingEffect
    {
        public ElfXEffect() : base(-1, new CardFilters.OwnersHandCreatureFilter(), new Durations.Indefinite()) { }

        public override IContinuousEffect Copy()
        {
            return new ElfXEffect();
        }

        public override string ToString()
        {
            return "Your creatures each cost 1 less to summon. They can't cost less than 1.";
        }
    }
}
