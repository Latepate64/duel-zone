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

        public override void Apply()
        {
            var cards = GetSelectableCards(Ability);
            var player = ControllerChooses ? Applier : Applier.Opponent;
            if (player != null)
            {
                var chosen = player.ChooseCards(cards, Minimum, Math.Min(Maximum, cards.Count()), ToString());
                Apply(Ability, chosen.ToArray());
            }
        }

        protected abstract void Apply(IAbility source, params ICard[] cards);

        protected abstract IEnumerable<ICard> GetSelectableCards(IAbility source);
    }
}
