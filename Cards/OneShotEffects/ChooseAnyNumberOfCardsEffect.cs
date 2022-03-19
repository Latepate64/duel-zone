using Common.Choices;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    public abstract class ChooseAnyNumberOfCardsEffect : OneShotEffect
    {
        public CardFilter Filter { get; }

        protected ChooseAnyNumberOfCardsEffect(CardFilter filter)
        {
            Filter = filter;
        }

        protected ChooseAnyNumberOfCardsEffect(ChooseAnyNumberOfCardsEffect effect)
        {
            Filter = effect.Filter.Copy();
        }

        protected abstract void Apply(IGame game, IAbility source, params ICard[] cards);

        public override object Apply(IGame game, IAbility source)
        {
            var player = game.GetPlayer(source.Owner);
            var cards = game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetPlayer(source.Owner)));
            if (cards.Any())
            {
                Apply(game, source, player.Choose(new CardSelectionInEffect(player.Id, cards, ToString()), game).Decision.Select(x => game.GetCard(x)).ToArray());
            }
            return null;
        }
    }
}
