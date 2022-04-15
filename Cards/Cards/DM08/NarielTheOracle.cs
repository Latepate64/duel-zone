using Cards.ContinuousEffects;
using Common;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM08
{
    class NarielTheOracle : Creature
    {
        public NarielTheOracle() : base("Nariel, the Oracle", 4, 1000, Engine.Subtype.LightBringer, Civilization.Light)
        {
            AddStaticAbilities(new NarielTheOracleEffect());
        }
    }

    class NarielTheOracleEffect : ContinuousEffect, ICannotAttackEffect
    {
        public NarielTheOracleEffect() : base()
        {
        }

        public bool Applies(Engine.ICard creature, IGame game)
        {
            return creature.Power >= 3000;
        }

        public override IContinuousEffect Copy()
        {
            return new NarielTheOracleEffect();
        }

        public override string ToString()
        {
            return "Creatures that have power 3000 or more can't attack.";
        }
    }
}
