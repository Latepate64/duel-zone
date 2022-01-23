using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    class TapChoiceEffect : OneShotEffect
    {
        public CardFilter Filter { get; }
        public int Minimum { get; }
        public int Maximum { get; }

        public TapChoiceEffect(CardFilter filter, int minimum, int maximum)
        {
            Filter = filter;
            Minimum = minimum;
            Maximum = maximum;
        }

        public TapChoiceEffect(TapChoiceEffect effect)
        {
            Filter = effect.Filter;
            Minimum = effect.Minimum;
            Maximum = effect.Maximum;
        }

        public override void Apply(Game game, Ability source)
        {
            var cards = game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetPlayer(source.Owner)));
            if (cards.Any())
            {
                if (Minimum >= cards.Count())
                {
                    Tap(cards);
                }
                else
                {
                    var player = game.GetPlayer(source.Owner);
                    if (player != null)
                    {
                        Tap(player.Choose(new GuidSelection(player.Id, cards.Select(x => x.Id), Minimum, Math.Min(Maximum, cards.Count()))).Decision.Select(x => game.GetCard(x)));
                    }
                }

            }
        }

        private static void Tap(IEnumerable<Card> cards)
        {
            foreach (var card in cards)
            {
                card.Tapped = true;
            }
        }

        public override OneShotEffect Copy()
        {
            return new TapChoiceEffect(this);
        }
    }
}