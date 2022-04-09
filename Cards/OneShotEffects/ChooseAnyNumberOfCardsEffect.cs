using Common.Choices;
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
                var chosen = source.GetController(game).Choose(new CardSelectionInEffect(source.GetController(game).Id, cards, ToString()), game).Decision.Select(x => game.GetCard(x)).ToArray();
                Apply(game, source, chosen);
                return chosen;
            }
            return cards;
        }

        protected abstract IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source);
    }
}
