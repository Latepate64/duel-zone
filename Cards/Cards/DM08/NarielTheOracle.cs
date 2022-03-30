using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM08
{
    class NarielTheOracle : Creature
    {
        public NarielTheOracle() : base("Nariel, the Oracle", 4, 1000, Subtype.LightBringer, Civilization.Light)
        {
            AddStaticAbilities(new NarielTheOracleEffect());
        }
    }

    class NarielTheOracleEffect : CannotAttackEffect
    {
        public NarielTheOracleEffect() : base(new CardFilters.BattleZoneMinPowerCreatureFilter(3000), new Durations.Indefinite())
        {
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
