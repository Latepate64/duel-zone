using DuelMastersModels.Effects.ContinuousEffects;

namespace DuelMastersModels.Abilities.StaticAbilities
{
    public interface IStaticAbility : IAbility
    {
        ReadOnlyContinuousEffectCollection ContinuousEffects { get; }
    }
}