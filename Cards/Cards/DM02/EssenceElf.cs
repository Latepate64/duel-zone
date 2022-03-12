using Common;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class EssenceElf : Creature
    {
        public EssenceElf() : base("Essence Elf", 2, 1000, Subtype.TreeFolk, Civilization.Nature)
        {
            AddAbilities(new StaticAbility(new Engine.ContinuousEffects.CostModifyingEffect(-1, new CardFilters.OwnersHandCardFilter { CardType = CardType.Spell })));
        }
    }
}
