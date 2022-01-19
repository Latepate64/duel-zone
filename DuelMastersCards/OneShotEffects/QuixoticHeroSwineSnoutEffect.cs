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

        public QuixoticHeroSwineSnoutEffect(QuixoticHeroSwineSnoutEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new QuixoticHeroSwineSnoutEffect(this);
        }

        public override void Apply(Game game)
        {
            game.ContinuousEffects.Add(new PowerModifyingEffect(new TargetFilter { Owner = Controller, Target = Source }, 3000, new UntilTheEndOfTheTurn()));
        }
    }
}
