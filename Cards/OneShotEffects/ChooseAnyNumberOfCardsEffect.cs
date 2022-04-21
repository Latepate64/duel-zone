using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    public abstract class ChooseAnyNumberOfCardsEffect : OneShotEffect
    {
        protected ChooseAnyNumberOfCardsEffect()
        {
        }

        protected ChooseAnyNumberOfCardsEffect(ChooseAnyNumberOfCardsEffect effect) : base(effect)
        {
        }

        protected abstract void Apply(IGame game, IAbility source, params ICard[] cards);

        public override void Apply(IGame game)
        {
            var cards = GetAffectedCards(game, GetSourceAbility(game));
            if (cards.Any())
            {
                var chosen = GetController(game).ChooseAnyNumberOfCards(cards, ToString());
                Apply(game, GetSourceAbility(game), chosen.ToArray());
            }
        }

        protected abstract IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source);
    }
}
