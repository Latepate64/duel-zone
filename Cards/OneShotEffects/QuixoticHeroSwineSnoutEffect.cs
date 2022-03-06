using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;

namespace Cards.OneShotEffects
{
    class QuixoticHeroSwineSnoutEffect : OneShotEffect
    {
        public QuixoticHeroSwineSnoutEffect()
        {
        }

        public QuixoticHeroSwineSnoutEffect(QuixoticHeroSwineSnoutEffect effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new QuixoticHeroSwineSnoutEffect(this);
        }

        public override void Apply(Game game, Ability source)
        {
            game.ContinuousEffects.Add(new PowerModifyingEffect(new TargetFilter { Target = source.Source }, 3000, new UntilTheEndOfTheTurn()));
        }

        public override string ToString()
        {
            return $"This creature gets +3000 power until the end of the turn.";
        }
    }
}
