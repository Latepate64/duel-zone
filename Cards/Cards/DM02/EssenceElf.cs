using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM02
{
    class EssenceElf : Creature
    {
        public EssenceElf() : base("Essence Elf", 2, 1000, Engine.Race.TreeFolk, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new EssenceElfEffect());
        }
    }

    class EssenceElfEffect : ContinuousEffect, ICostModifyingEffect, IMinimumCostModifyingEffect
    {
        public EssenceElfEffect() : base()
        {
        }

        public override IContinuousEffect Copy()
        {
            return new EssenceElfEffect();
        }

        public int GetChange(ICard card, IGame game)
        {
            return card.OwnerPlayer == Controller && card.CardType == CardType.Spell ? -1 : 0;
        }

        public int GetMinimumCost(ICard card, IGame game)
        {
            return card.OwnerPlayer == Controller && card.CardType == CardType.Spell ? 1 : 0;
        }

        public override string ToString()
        {
            return "Your spells each cost 1 less to cast. They can't cost less than 1.";
        }
    }
}
