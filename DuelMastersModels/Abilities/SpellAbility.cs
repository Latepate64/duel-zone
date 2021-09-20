using DuelMastersModels.Effects.OneShotEffects;

namespace DuelMastersModels.Abilities
{
    internal class SpellAbility : NonStaticAbility
    {
        internal SpellAbility(System.Collections.Generic.Queue<OneShotEffect> effects) : base(effects)
        { }
    }
}
