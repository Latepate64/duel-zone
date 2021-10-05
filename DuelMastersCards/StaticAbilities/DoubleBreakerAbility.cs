using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;

namespace DuelMastersCards.StaticAbilities
{
    public class DoubleBreakerAbility : StaticAbility
    {
        public DoubleBreakerAbility() : base()
        {
            ContinuousEffects.Add(new DoubleBreakerEffect());
        }

        protected DoubleBreakerAbility(DoubleBreakerAbility ability) : base(ability) { }

        public override Ability Copy()
        {
            return new DoubleBreakerAbility(this);
        }
    }
}