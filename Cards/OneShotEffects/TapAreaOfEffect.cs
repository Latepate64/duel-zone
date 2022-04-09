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

        public override object Apply(IGame game, IAbility source)
        {
            var cards = GetAffectedCards(game, source).ToArray();
            source.GetController(game).Tap(game, cards);
            return cards.Any();
        }

        protected abstract IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source);
    }
}
