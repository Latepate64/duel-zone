using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM11
{
    class MerleeTheOracle : WaveStrikerCreature
    {
        public MerleeTheOracle() : base("Merlee, the Oracle", 2, 1500, Subtype.LightBringer, Civilization.Light)
        {
            AddWaveStrikerAbility(new MerleeTheOracleEffect());
        }
    }

    class MerleeTheOracleEffect : ContinuousEffect, IPowerModifyingEffect
    {
        public MerleeTheOracleEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter(), new Durations.Indefinite())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new MerleeTheOracleEffect();
        }

        public void ModifyPower(IGame game)
        {
            GetAffectedCards(game).ToList().ForEach(x => x.Power += 1000);
        }

        public override string ToString()
        {
            return "Each of your creatures in the battle zone gets +1000 power.";
        }
    }
}
