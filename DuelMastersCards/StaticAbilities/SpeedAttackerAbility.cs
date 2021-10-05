using DuelMastersCards.CardFilters;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;

namespace DuelMastersCards.StaticAbilities
{
    public class SpeedAttackerAbility : StaticAbility
    {
        public SpeedAttackerAbility() : base()
        {
            ContinuousEffects.Add(new SpeedAttackerEffect(new SourceFilter()));
        }

        protected SpeedAttackerAbility(SpeedAttackerAbility ability) : base(ability) { }

        public override Ability Copy()
        {
            return new SpeedAttackerAbility(this);
        }
    }
}

