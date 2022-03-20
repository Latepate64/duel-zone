using Common;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class ElfX : Creature
    {
        public ElfX() : base("Elf-X", 4, 2000, Subtype.TreeFolk, Civilization.Nature)
        {
            AddAbilities(new ElfXAbility());
        }
    }

    class ElfXAbility : StaticAbility
    {
        public ElfXAbility() : base(new Engine.ContinuousEffects.CostModifyingEffect(-1, new CardFilters.OwnersHandCreatureFilter()))
        {
        }

        public override string ToString()
        {
            return "Your creatures each cost 1 less to summon. They can't cost less than 1.";
        }
    }
}
