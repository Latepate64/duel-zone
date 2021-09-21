using DuelMastersModels.Effects.OneShotEffects;

namespace DuelMastersModels.Abilities
{
    internal abstract class SpellAbility : NonStaticAbility
    {
        internal SpellAbility(System.Collections.Generic.Queue<OneShotEffect> effects, Cards.Card source) : base(effects, source)
        { }
    }
}
