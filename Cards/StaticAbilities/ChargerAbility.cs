using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class ChargerAbility : StaticAbility
    {
        public ChargerAbility() : base(new ThisSpellHasChargerEffect())
        {
        }
    }

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
