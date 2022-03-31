using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM08
{
    class SeniaOrchardAvenger : TurboRushCreature
    {
        public SeniaOrchardAvenger() : base("Senia, Orchard Avenger", 4, 3000, Subtype.TreeFolk, Civilization.Nature)
        {
            AddTurboRushAbility(new SeniaOrchardAvengerEffect());
        }
    }

    class SeniaOrchardAvengerEffect : ContinuousEffects.ThisCreatureGetsPowerAndDoubleBreakerEffect
    {
        public SeniaOrchardAvengerEffect() : base(5000, new Durations.Indefinite())
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
    }
}
