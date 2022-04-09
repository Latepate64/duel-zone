using Engine;
using Engine.Abilities;
using Common.Choices;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    public abstract class CardSelectionEffect : OneShotEffect
    {
        public int Minimum { get; }
        public int Maximum { get; }
        public bool ControllerChooses { get; }

        protected CardSelectionEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses)
        {
            Minimum = minimum;
            Maximum = maximum;
            ControllerChooses = controllerChooses;
        }

        protected CardSelectionEffect(CardSelectionEffect effect)
        {
            Minimum = effect.Minimum;
            Maximum = effect.Maximum;
            ControllerChooses = effect.ControllerChooses;
        }

        public override IEnumerable<ICard> Apply(IGame game, IAbility source)
        {
            var cards = GetSelectableCards(game, source);
            if (cards.Any())
            {
                if (Minimum >= cards.Count())
                {
                    Apply(game, source, cards.ToArray());
                }
                else
                {
                    var player = ControllerChooses ? source.GetController(game) : source.GetOpponent(game);
                    if (player != null)
                    {
                        var chosen = player.Choose(new BoundedCardSelectionInEffect(player.Id, cards, Minimum, Math.Min(Maximum, cards.Count()), ToString()), game).Decision.Select(x => game.GetCard(x)).ToArray();
                        Apply(game, source, chosen);
                        return chosen;
                    }
                }
            }
            return cards;
        }

        protected abstract void Apply(IGame game, IAbility source, params ICard[] cards);

        protected abstract IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source);
    }
}
