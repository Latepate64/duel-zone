using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM02
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

        public int GetChange(ICard card, IGame game)
        {
            return card.Owner == Controller && card.CardType == CardType.Creature ? -1 : 0;
        }

        public int GetMinimumCost(ICard card, IGame game)
        {
            return card.Owner == Controller && card.CardType == CardType.Creature ? 1 : 0;
        }

        public override string ToString()
        {
            return "Your creatures each cost 1 less to summon. They can't cost less than 1.";
        }
    }
}
