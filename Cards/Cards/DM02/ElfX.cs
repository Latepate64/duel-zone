using Common;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class ElfX : Creature
    {
        public ElfX() : base("Elf-X", 4, 2000, Subtype.TreeFolk, Civilization.Nature)
        {
            AddAbilities(new StaticAbility(new Engine.ContinuousEffects.CostModifyingEffect(-1, new CardFilters.OwnersHandCreatureFilter())));
        }
    }
}
