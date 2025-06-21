using ContinuousEffects;
using Engine;
using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM07
{
    class BexTheOracle : Creature
    {
        public BexTheOracle() : base("Bex, the Oracle", 3, 2500, Interfaces.Race.LightBringer, Interfaces.Civilization.Light)
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

        public void AddAbility(IGame game)
        {
            if (!Controller.ShieldZone.HasCards)
            {
                game.AddAbility(Source, new StaticAbility(new ThisCreatureHasBlockerEffect()));
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
