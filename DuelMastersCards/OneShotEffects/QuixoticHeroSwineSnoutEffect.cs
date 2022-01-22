using DuelMastersCards.CardFilters;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace DuelMastersCards.OneShotEffects
{
    public class QuixoticHeroSwineSnoutEffect : OneShotEffect
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
    }
}
