using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class TapThisCreatureEffect : TapAreaOfEffect
    {
        public TapThisCreatureEffect() : base(new Engine.TargetFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new TapThisCreatureEffect();
        }

        public override string ToString()
        {
            return "Tap this creature.";
        }
    }
}
