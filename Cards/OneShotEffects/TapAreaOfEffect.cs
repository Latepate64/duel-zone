using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    abstract class TapAreaOfEffect : OneShotEffect
    {
        protected TapAreaOfEffect()
        {
        }

        protected TapAreaOfEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply()
        {
            var cards = GetAffectedCards(Ability).ToArray();
            Applier.Tap(cards);
        }

        protected abstract IEnumerable<ICard> GetAffectedCards(IAbility source);
    }
}
