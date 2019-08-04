using DuelMastersModels.Effects.OneShotEffects;
using System.Collections.ObjectModel;

namespace DuelMastersModels.Abilities
{
    public class SpellAbility : NonStaticAbility
    {
        public SpellAbility(Collection<OneShotEffect> effects, Player controller, Cards.Spell spell) : base(effects, controller, spell)
        { }
    }
}
