using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class UntapThisCreatureEffect : UntapAreaOfEffect
    {
        public UntapThisCreatureEffect() : base(new Engine.TargetFilter()) { }

        public override IOneShotEffect Copy()
        {
            return new UntapThisCreatureEffect();
        }

        public override string ToString()
        {
            return "Untap this creature.";
        }
    }
}
