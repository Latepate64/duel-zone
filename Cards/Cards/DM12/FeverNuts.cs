using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM12
{
    class FeverNuts : Creature
    {
        public FeverNuts() : base("Fever Nuts", 3, 1000, Engine.Race.WildVeggies, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new FeverNutsEffect());
        }
    }

    class FeverNutsEffect : ContinuousEffect, ICostModifyingEffect, IMinimumCostModifyingEffect
    {
        public FeverNutsEffect() : base() { }

        public override IContinuousEffect Copy()
        {
            return new FeverNutsEffect();
        }

        public int GetChange(ICard card)
        {
            return card.IsCreature ? -1 : 0;
        }

        public int GetMinimumCost(ICard card)
        {
            return card.IsCreature ? 1 : 0;
        }

        public override string ToString()
        {
            return "Your creatures and your opponent's creatures each cost up to 1 less to summon. They can't cost less than 1.";
        }
    }
}
