using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class LeapingTornadoHornEffect : PowerAttackerMultiplierEffect
    {
        public LeapingTornadoHornEffect(int power = 1000) : base(power)
        {
        }

        public LeapingTornadoHornEffect(PowerAttackerMultiplierEffect effect) : base(effect)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new LeapingTornadoHornEffect(this);
        }

        public override string ToString()
        {
            return $"While attacking, this creature gets +{Power} power for each other creature you have in the battle zone.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return game.BattleZone.GetOtherTappedCreatures(Applier, Source).Count();
        }
    }
}