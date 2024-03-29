﻿using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM11
{
    class MerleeTheOracle : WaveStrikerCreature
    {
        public MerleeTheOracle() : base("Merlee, the Oracle", 2, 1500, Race.LightBringer, Civilization.Light)
        {
            AddWaveStrikerAbility(new MerleeTheOracleEffect());
        }
    }

    class MerleeTheOracleEffect : ContinuousEffect, IPowerModifyingEffect
    {
        public MerleeTheOracleEffect() : base()
        {
        }

        public override IContinuousEffect Copy()
        {
            return new MerleeTheOracleEffect();
        }

        public void ModifyPower(IGame game)
        {
            game.BattleZone.GetCreatures(Controller.Id).ToList().ForEach(x => x.Power += 1000);
        }

        public override string ToString()
        {
            return "Each of your creatures in the battle zone gets +1000 power.";
        }
    }
}
