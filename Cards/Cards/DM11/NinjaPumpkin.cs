﻿using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM11
{
    class NinjaPumpkin : WaveStrikerCreature
    {
        public NinjaPumpkin() : base("Ninja Pumpkin", 3, 2000, Subtype.WildVeggies, Civilization.Nature)
        {
            AddWaveStrikerAbility(new NinjaPumpkinEffect());
        }
    }

    class NinjaPumpkinEffect : ContinuousEffects.ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect, IPowerModifyingEffect
    {
        public NinjaPumpkinEffect() : base(5000)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new NinjaPumpkinEffect();
        }

        public void ModifyPower(IGame game)
        {
            GetAffectedCards(game).ToList().ForEach(x => x.Power += 4000);
        }

        public override string ToString()
        {
            return "This creature gets +4000 power and can't be blocked by any creature that has power 5000 or less.";
        }
    }
}