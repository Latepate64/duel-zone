using Common;
using Engine.Abilities;

namespace Cards.StaticAbilities
{
    class TapAbilityAddingAbility : StaticAbility
    {
        public TapAbilityAddingAbility(Civilization civilization, IOneShotEffect effect) : base(new ContinuousEffects.TapAbilityAddingEffect(civilization, effect))
        {
        }
    }
}