using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class CoccoLupia : Creature
    {
        public CoccoLupia() : base("Cocco Lupia", 3, 1000, Race.FireBird, Civilization.Fire)
        {
            AddStaticAbilities(new CoccoLupiaEffect());
        }
    }

    class CoccoLupiaEffect : ContinuousEffect, ICostModifyingEffect, IMinimumCostModifyingEffect
    {
        public CoccoLupiaEffect()
        {
        }

        public CoccoLupiaEffect(CoccoLupiaEffect effect) : base(effect)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new CoccoLupiaEffect(this);
        }

        public int GetChange(ICard card, IGame game)
        {
            return card.Owner == Applier && card.IsDragon ? -2 : 0;
        }

        public int GetMinimumCost(ICard card, IGame game)
        {
            return card.Owner == Applier && card.IsDragon ? 2 : 0;
        }

        public override string ToString()
        {
            return "Your creatures that have Dragon in their race each cost 2 less to summon. They can't cost less than 2.";
        }
    }
}
