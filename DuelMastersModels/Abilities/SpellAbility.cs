using DuelMastersModels.Effects.OneShotEffects;

namespace DuelMastersModels.Abilities
{
    internal class SpellAbility : NonStaticAbility
    {
        internal SpellAbility(ReadOnlyOneShotEffectCollection effects) : base(effects)
        { }
    }
}
