using Engine;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Collections.Generic;

namespace Cards.DM08
{
    sealed class SeniaOrchardAvenger : TurboRushCreature
    {
        public SeniaOrchardAvenger() : base("Senia, Orchard Avenger", 4, 3000, Race.TreeFolk, Civilization.Nature)
        {
            AddTurboRushAbility(new SeniaOrchardAvengerEffect());
        }
    }

    sealed class SeniaOrchardAvengerEffect : ContinuousEffects.GetPowerAndDoubleBreakerEffect
    {
        public SeniaOrchardAvengerEffect() : base(5000)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new SeniaOrchardAvengerEffect();
        }

        public override string ToString()
        {
            return "This creature gets +5000 power and has \"double breaker\".";
        }

        protected override List<ICreature> GetAffectedCards(IGame game)
        {
            return [Source as Creature];
        }
    }
}
