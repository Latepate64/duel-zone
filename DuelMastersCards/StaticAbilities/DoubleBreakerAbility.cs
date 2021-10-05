using DuelMastersCards.CardFilters;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;

namespace DuelMastersCards.StaticAbilities
{
    public class DoubleBreakerAbility : StaticAbility
    {
        public DoubleBreakerAbility() : base()
        {
            ContinuousEffects.Add(new DoubleBreakerEffect(new SourceFilter()));
        }

        protected DoubleBreakerAbility(DoubleBreakerAbility ability) : base(ability) { }

        public override Ability Copy()
        {
            return new DoubleBreakerAbility(this);
        }
    }
}