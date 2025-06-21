using ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.DM02
{
    class ElfX : Creature
    {
        public ElfX() : base("Elf-X", 4, 2000, Engine.Race.TreeFolk, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ElfXEffect());
        }
    }

    class ElfXEffect : ContinuousEffect, ICostModifyingEffect, IMinimumCostModifyingEffect
    {
        public ElfXEffect() : base() { }

        public override IContinuousEffect Copy()
        {
            return new ElfXEffect();
        }

        public int GetChange(Card card, IGame game)
        {
            return card.Owner == Controller && card is Creature ? -1 : 0;
        }

        public int GetMinimumCost(Card card, IGame game)
        {
            return card.Owner == Controller && card is Creature ? 1 : 0;
        }

        public override string ToString()
        {
            return "Your creatures each cost 1 less to summon. They can't cost less than 1.";
        }
    }
}
