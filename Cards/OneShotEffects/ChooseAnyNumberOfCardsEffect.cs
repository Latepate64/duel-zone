using Common.Choices;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    public abstract class ChooseAnyNumberOfCardsEffect : OneShotEffect
    {
        public ICardFilter Filter { get; }

        protected ChooseAnyNumberOfCardsEffect(CardFilter filter)
        {
            Filter = filter;
        }

        protected ChooseAnyNumberOfCardsEffect(ChooseAnyNumberOfCardsEffect effect)
        {
            Filter = effect.Filter.Copy();
        }

        protected abstract void Apply(IGame game, IAbility source, params ICard[] cards);

        public override IEnumerable<ICard> Apply(IGame game, IAbility source)
        {
            var player = game.GetPlayer(source.Controller);
            var cards = game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetPlayer(source.Controller)));
            if (cards.Any())
            {
                var chosen = player.Choose(new CardSelectionInEffect(player.Id, cards, ToString()), game).Decision.Select(x => game.GetCard(x)).ToArray();
                Apply(game, source, chosen);
                return chosen;
            }
            return cards;
        }
    }
}
