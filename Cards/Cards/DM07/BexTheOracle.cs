using Cards.ContinuousEffects;
using Engine;
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

    class BexEffect : ContinuousEffect, IAbilityAddingEffect
    {
        public BexEffect() : base()
        {
        }

        public BexEffect(BexEffect effect) : base(effect)
        {
        }

        public void AddAbility()
        {
            if (!Applier.ShieldZone.HasCards)
            {
                Game.AddAbility(Source, new StaticAbilities.BlockerAbility());
            }
        }

        public override IContinuousEffect Copy()
        {
            return new BexEffect(this);
        }

        public override string ToString()
        {
            return "While you have no shields, this creature has \"Blocker.\"";
        }
    }
}
