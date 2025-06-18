using Engine;
using Engine.Abilities;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    public abstract class CardSelectionEffect<T> : OneShotEffect where T : Card
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

        protected CardSelectionEffect(CardSelectionEffect<T> effect) : base(effect)
        {
            Minimum = effect.Minimum;
            Maximum = effect.Maximum;
            ControllerChooses = effect.ControllerChooses;
        }

        public override void Apply(IGame game)
        {
            var cards = GetSelectableCards(game, Ability);
            var player = ControllerChooses ? Controller : GetOpponent(game);
            if (player != null)
            {
                var chosen = player.ChooseCards(cards, Minimum, Math.Min(Maximum, cards.Count()), ToString());
                Apply(game, Ability, [.. chosen]);
            }
        }

        protected abstract void Apply(IGame game, IAbility source, params T[] cards);

        protected abstract IEnumerable<T> GetSelectableCards(IGame game, IAbility source);
    }

    public abstract class CreatureSelectionEffect : CardSelectionEffect<Engine.Creature>
    {
        protected CreatureSelectionEffect(CreatureSelectionEffect effect) : base(effect)
        {
        }

        protected CreatureSelectionEffect(int minimum, int maximum, bool controllerChooses) : base(minimum, maximum,
            controllerChooses)
        {
        }
    }
}
