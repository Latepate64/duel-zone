using Engine;
using Engine.Abilities;
using Engine.Durations;

namespace Cards.OneShotEffects
{
    class ThisCreatureGetsBlockerUntilTheEndOfTheTurnEffect : GrantAbilityAreaOfEffect
    {
        public ThisCreatureGetsBlockerUntilTheEndOfTheTurnEffect(ThisCreatureGetsBlockerUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
        }

        public ThisCreatureGetsBlockerUntilTheEndOfTheTurnEffect() : base(new TargetFilter(), new UntilTheEndOfTheTurn(), new StaticAbilities.BlockerAbility())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ThisCreatureGetsBlockerUntilTheEndOfTheTurnEffect(this);
        }

        public override string ToString()
        {
            return "This creature gets \"blocker\" until the end of the turn.";
        }
    }
}
