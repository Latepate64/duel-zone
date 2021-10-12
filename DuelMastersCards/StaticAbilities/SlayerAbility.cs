using DuelMastersCards.CardFilters;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace DuelMastersCards.StaticAbilities
{
    public class SlayerAbility : StaticAbility
    {
        public SlayerAbility()
        {
            ContinuousEffects.Add(new SlayerEffect(new TargetFilter(), new Indefinite()));
        }

        public SlayerAbility(StaticAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new SlayerAbility(this);
        }
    }
}
