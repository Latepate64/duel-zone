using Engine;
using Engine.Abilities;
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

        protected CardSelectionEffect(int minimum, int maximum, bool controllerChooses)
        {
            Minimum = minimum;
            Maximum = maximum;
            ControllerChooses = controllerChooses;
        }

        protected CardSelectionEffect(CardSelectionEffect effect) : base(effect)
        {
            Minimum = effect.Minimum;
            Maximum = effect.Maximum;
            ControllerChooses = effect.ControllerChooses;
        }

        public override void Apply(IGame game)
        {
            var cards = GetSelectableCards(game, Ability);
            var player = ControllerChooses ? Applier : Applier.Opponent;
            if (player != null)
            {
                var chosen = player.ChooseCards(cards, Minimum, Math.Min(Maximum, cards.Count()), ToString());
                Apply(game, Ability, chosen.ToArray());
            }
        }

        protected abstract void Apply(IGame game, IAbility source, params ICard[] cards);

        protected abstract IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source);
    }
}
