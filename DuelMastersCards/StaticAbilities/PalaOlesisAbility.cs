using DuelMastersCards.CardFilters;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace DuelMastersCards.StaticAbilities
{
    public class PalaOlesisAbility : StaticAbility
    {
        public PalaOlesisAbility()
        {
            // During your opponent's turn, each of your other creatures gets +2000 power.
            ContinuousEffects.Add(new PowerModifyingEffect(new PalaOlesisFilter(), 2000, new Indefinite()));
        }

        public PalaOlesisAbility(StaticAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new PalaOlesisAbility(this);
        }
    }
}
