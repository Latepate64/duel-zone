using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class DestroyThisCreatureEffect : DestroyAreaOfEffect
    {
        public DestroyThisCreatureEffect() : base(new TargetFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DestroyThisCreatureEffect();
        }

        public override string ToString()
        {
            return "Destroy this creature.";
        }
    }
}
