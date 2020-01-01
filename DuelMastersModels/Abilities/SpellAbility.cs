using DuelMastersModels.Effects.OneShotEffects;

namespace DuelMastersModels.Abilities
{
    internal class SpellAbility : NonStaticAbility
    {
        internal SpellAbility(ReadOnlyOneShotEffectCollection effects, Player controller, Cards.Spell spell) : base(effects, controller, spell)
        { }
    }
}
