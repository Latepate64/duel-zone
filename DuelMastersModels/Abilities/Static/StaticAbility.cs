using DuelMastersModels.Effects.ContinuousEffects;

namespace DuelMastersModels.Abilities.Static
{
    public abstract class StaticAbility : Ability
    {
        public ReadOnlyContinuousEffectCollection ContinuousEffects { get; private set; }

        protected StaticAbility(ContinuousEffect continuousEffect)
        {
            ContinuousEffects = new ReadOnlyContinuousEffectCollection(continuousEffect);
        }

        protected StaticAbility(ReadOnlyContinuousEffectCollection continuousEffects)
        {
            ContinuousEffects = continuousEffects;
        }
    }
}
