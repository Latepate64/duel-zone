using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class LeapingTornadoHornEffect : PowerAttackerMultiplierEffect
    {
        public LeapingTornadoHornEffect() : base(1000)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new LeapingTornadoHornEffect();
        }

        public override string ToString()
        {
            return "While attacking, this creature gets +1000 power for each other creature you have in the battle zone.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return game.BattleZone.GetOtherTappedCreatures(Controller.Id, GetSourceCard(game).Id).Count();
        }
    }
}