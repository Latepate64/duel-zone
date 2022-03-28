﻿using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisSpellHasChargerEffect : ChargerEffect
    {
        public ThisSpellHasChargerEffect() : base(new Engine.TargetFilter(), new Durations.Indefinite())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisSpellHasChargerEffect();
        }

        public override string ToString()
        {
            return "Charger";
        }
    }
}