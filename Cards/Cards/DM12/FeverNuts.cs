using Common;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM12
{
    class FeverNuts : Creature
    {
        public FeverNuts() : base("Fever Nuts", 3, 1000, Subtype.WildVeggies, Civilization.Nature)
        {
            AddStaticAbilities(new FeverNutsEffect());
        }
    }

    class FeverNutsEffect : ContinuousEffect, ICostModifyingEffect
    {
        public FeverNutsEffect() : base(new HandCreatureFilter()) { }

        public override IContinuousEffect Copy()
        {
            return new FeverNutsEffect();
        }

        public int GetChange()
        {
            return -1;
        }

        public override string ToString()
        {
            return "Your creatures and your opponent's creatures each cost up to 1 less to summon. They can't cost less than 1.";
        }
    }

    class HandCreatureFilter : CardFilters.HandCardFilter
    {
        public override bool Applies(Engine.ICard card, IGame game, Engine.IPlayer player)
        {
            return base.Applies(card, game, player) && card.CardType == CardType.Creature;
        }

        public override CardFilter Copy()
        {
            return new HandCreatureFilter();
        }
    }
}
