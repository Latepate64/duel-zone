using ContinuousEffects;
using Engine;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM12
{
    sealed class FeverNuts : Creature
    {
        public FeverNuts() : base("Fever Nuts", 3, 1000, Interfaces.Race.WildVeggies, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new FeverNutsEffect());
        }
    }

    sealed class FeverNutsEffect : ContinuousEffect, ICostModifyingEffect, IMinimumCostModifyingEffect
    {
        public FeverNutsEffect() : base() { }

        public override IContinuousEffect Copy()
        {
            return new FeverNutsEffect();
        }

        public int GetChange(ICard card, IGame game)
        {
            return card is Creature ? -1 : 0;
        }

        public int GetMinimumCost(ICard card, IGame game)
        {
            return card is Creature ? 1 : 0;
        }

        public override string ToString()
        {
            return "Your creatures and your opponent's creatures each cost up to 1 less to summon. They can't cost less than 1.";
        }
    }
}
