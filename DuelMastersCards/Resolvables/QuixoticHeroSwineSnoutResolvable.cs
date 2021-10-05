using DuelMastersCards.CardFilters;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace DuelMastersCards.Resolvables
{
    public class QuixoticHeroSwineSnoutResolvable : Resolvable
    {
        public QuixoticHeroSwineSnoutResolvable()
        {
        }

        public QuixoticHeroSwineSnoutResolvable(QuixoticHeroSwineSnoutResolvable ability) : base(ability)
        {
        }

        public override Resolvable Copy()
        {
            return new QuixoticHeroSwineSnoutResolvable(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            duel.ContinuousEffects.Add(new PowerModifyingEffect(new SourceFilter { Owner = Controller, Source = Source }, 3000) { Duration = new UntilTheEndOfTheTurn() });
            return null;
        }
    }
}
