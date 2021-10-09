using DuelMastersCards.CardFilters;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace DuelMastersCards.StaticAbilities
{
    public class BlockerAbility : StaticAbility
    {
        public BlockerAbility() : base()
        {
            ContinuousEffects.Add(new BlockerEffect(new TargetFilter(), new Indefinite()));
        }

        public BlockerAbility(StaticAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new BlockerAbility(this);
        }
    }
}
