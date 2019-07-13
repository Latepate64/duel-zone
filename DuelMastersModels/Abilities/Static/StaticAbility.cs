using DuelMastersModels.Effects.ContinuousEffects;
using System.Collections.ObjectModel;

namespace DuelMastersModels.Abilities.Static
{
    public abstract class StaticAbility : Ability
    {
        public Collection<ContinuousEffect> ContinuousEffects { get; private set; }

        protected StaticAbility(ContinuousEffect continuousEffect)
        {
            ContinuousEffects = new Collection<ContinuousEffect>() { continuousEffect };
        }

        protected StaticAbility(Collection<ContinuousEffect> continuousEffects)
        {
            ContinuousEffects = continuousEffects;
        }
    }
}
