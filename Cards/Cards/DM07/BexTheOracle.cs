using Cards.ContinuousEffects;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM07
{
    class BexTheOracle : Creature
    {
        public BexTheOracle() : base("Bex, the Oracle", 3, 2500, Engine.Race.LightBringer, Engine.Civilization.Light)
        {
            AddStaticAbilities(new BexEffect());
        }
    }

    class BexEffect : WhileYouHaveNoShieldsEffect
    {
        public BexEffect() : base(new StaticAbilities.BlockerAbility())
        {
        }

        public BexEffect(IContinuousEffect effect) : base(effect)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new BexEffect(this);
        }
    }
}
