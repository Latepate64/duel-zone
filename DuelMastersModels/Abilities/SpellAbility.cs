using DuelMastersModels.Effects.OneShotEffects;
using System.Collections.ObjectModel;

namespace DuelMastersModels.Abilities
{
    public class SpellAbility : NonStaticAbility
    {
        public SpellAbility(Collection<OneShotEffect> effects, Player controller) : base(effects, controller)
        { }
    }
}
