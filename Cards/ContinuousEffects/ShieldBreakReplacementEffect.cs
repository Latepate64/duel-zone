using Engine;
using Engine.GameEvents;

namespace Cards.ContinuousEffects
{
    abstract class ShieldBreakReplacementEffect : ReplacementEffect
    {
        public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
        {
            throw new System.NotImplementedException();
        }

        public override bool CanBeApplied(IGameEvent gameEvent, IGame game)
        {
            throw new System.NotImplementedException();
        }
    }
}
