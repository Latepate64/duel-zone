using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.Effects.ContinuousEffects;
using DuelMastersModels.Effects.Periods;

namespace DuelMastersCards.TriggeredAbilities
{
    public class QuixoticHeroSwineSnoutAbility : AnotherCreaturePutIntoBattleZoneAbility
    {
        public QuixoticHeroSwineSnoutAbility()
        {
        }

        public QuixoticHeroSwineSnoutAbility(QuixoticHeroSwineSnoutAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new QuixoticHeroSwineSnoutAbility(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            duel.ContinuousEffects.Add(new PowerModifyingEffect(new UntilTheEndOfTheTurn(), 3000, Source));
            return null;
        }
    }
}
