using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Collections.Generic;

namespace Cards.Cards.DM08
{
    class SeniaOrchardAvenger : TurboRushCreature
    {
        public SeniaOrchardAvenger() : base("Senia, Orchard Avenger", 4, 3000, Engine.Subtype.TreeFolk, Civilization.Nature)
        {
            AddTurboRushAbility(new SeniaOrchardAvengerEffect());
        }
    }

    class SeniaOrchardAvengerEffect : ContinuousEffects.GetPowerAndDoubleBreakerEffect
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

        protected override List<Engine.ICard> GetAffectedCards(IGame game)
        {
            return new List<Engine.ICard> { GetSourceCard(game) };
        }
    }
}
