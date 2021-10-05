using DuelMastersCards.CardFilters;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace DuelMastersCards.StaticAbilities
{
    public class DoubleBreakerAbility : StaticAbility
    {
        public DoubleBreakerAbility() : base()
        {
            ContinuousEffects.Add(new DoubleBreakerEffect(new TargetFilter(), new Indefinite()));
        }

        protected DoubleBreakerAbility(DoubleBreakerAbility ability) : base(ability) { }

        public override Ability Copy()
        {
            return new DoubleBreakerAbility(this);
        }
    }
}