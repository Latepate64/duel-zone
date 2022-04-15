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

        public override IEnumerable<ICard> Apply(IGame game, IAbility source)
        {
            var cards = GetAffectedCards(game, source);
            if (cards.Any())
            {
                var chosen = source.GetController(game).ChooseAnyNumberOfCards(cards, ToString());
                Apply(game, source, chosen.ToArray());
                return chosen;
            }
            return cards;
        }

        protected abstract IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source);
    }
}
