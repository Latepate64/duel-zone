using ContinuousEffects;
using Engine;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM08
{
    sealed class NarielTheOracle : Creature
    {
        public NarielTheOracle() : base("Nariel, the Oracle", 4, 1000, Race.LightBringer, Civilization.Light)
        {
            AddStaticAbilities(new NarielTheOracleEffect());
        }
    }

    sealed class NarielTheOracleEffect : ContinuousEffect, ICannotAttackEffect
    {
        public NarielTheOracleEffect() : base()
        {
        }

        public bool CannotAttack(ICreature creature, IGame game)
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
