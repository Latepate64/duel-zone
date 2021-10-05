using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;

namespace DuelMastersCards.StaticAbilities
{
    public class SpeedAttackerAbility : StaticAbility
    {
        public SpeedAttackerAbility() : base()
        {
            ContinuousEffects.Add(new SpeedAttackerEffect());
        }

        protected SpeedAttackerAbility(SpeedAttackerAbility ability) : base(ability) { }

        public override Ability Copy()
        {
            return new SpeedAttackerAbility(this);
        }
    }
}

