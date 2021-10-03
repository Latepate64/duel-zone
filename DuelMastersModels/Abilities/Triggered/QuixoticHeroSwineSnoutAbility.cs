using DuelMastersModels.Choices;
using DuelMastersModels.Effects.ContinuousEffects;
using DuelMastersModels.Effects.Periods;

namespace DuelMastersModels.Abilities.Triggered
{
    public class QuixoticHeroSwineSnoutAbility : AnotherCreaturePutIntoBattleZoneAbility
    {
        public QuixoticHeroSwineSnoutAbility()
        {
        }

        public QuixoticHeroSwineSnoutAbility(TriggeredAbility ability) : base(ability)
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
