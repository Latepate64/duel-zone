using Engine;
using Engine.Abilities;
using Common.Choices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    public abstract class CardSelectionEffect : OneShotEffect
    {
        public CardFilter Filter { get; }
        public int Minimum { get; }
        public int Maximum { get; }
        public bool ControllerChooses { get; }

        protected CardSelectionEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses)
        {
            Filter = filter;
            Minimum = minimum;
            Maximum = maximum;
            ControllerChooses = controllerChooses;
        }

        protected CardSelectionEffect(CardSelectionEffect effect)
        {
            Filter = effect.Filter;
            Minimum = effect.Minimum;
            Maximum = effect.Maximum;
            ControllerChooses = effect.ControllerChooses;
        }

        public override void Apply(Game game, Ability source)
        {
            var cards = game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetPlayer(source.Owner)));
            if (cards.Any())
            {
                if (Minimum >= cards.Count())
                {
                    Apply(game, source, cards);
                }
                else
                {
                    var player = game.GetPlayer(ControllerChooses ? source.Owner : game.GetOpponent(source.Owner));
                    if (player != null)
                    {
                        Apply(game, source, player.Choose(new BoundedCardSelectionInEffect(player.Id, cards, Minimum, Math.Min(Maximum, cards.Count()), ToString()), game).Decision.Select(x => game.GetCard(x)));
                    }
                }
            }
        }

        protected abstract void Apply(Game game, Ability source, IEnumerable<Card> cards);

        protected string GetAmountAsText()
        {
            if (Minimum == 0)
            {
                return $"up to {Maximum}";
            }
            else if (Minimum < Maximum)
            {
                return $"from {Minimum} up to {Maximum}";
            }
            else if (Minimum == 1)
            {
                return "one";
            }
            else
            {
                return Maximum.ToString();
            }
        }
    }
}
