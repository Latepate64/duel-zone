using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM11
{
    class MerleeTheOracle : WaveStrikerCreature
    {
        public MerleeTheOracle() : base("Merlee, the Oracle", 2, 1500, Subtype.LightBringer, Civilization.Light)
        {
            AddWaveStrikerAbility(new MerleeTheOracleEffect());
        }
    }

    class MerleeTheOracleEffect : PowerModifyingEffect
    {
        public MerleeTheOracleEffect() : base(1000, new CardFilters.OwnersBattleZoneCreatureFilter(), new Durations.Indefinite())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new MerleeTheOracleEffect();
        }

        public override string ToString()
        {
            return "Each of your creatures in the battle zone gets +1000 power.";
        }
    }
}
