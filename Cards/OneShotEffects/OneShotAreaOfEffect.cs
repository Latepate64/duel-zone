using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    abstract class OneShotAreaOfEffect : OneShotEffect
    {
        protected OneShotAreaOfEffect()
        {
        }

        protected OneShotAreaOfEffect(OneShotAreaOfEffect effect) : base(effect)
        {
        }

        protected abstract IEnumerable<ICard> GetAffectedCards(IAbility source);
    }
}
