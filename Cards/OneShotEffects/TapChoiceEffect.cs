using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    class TapChoiceEffect : CardSelectionEffect
    {
        public TapChoiceEffect(int minimum, int maximum, bool ownerChooses) : base(new CardFilters.OpponentsBattleZoneChoosableCreatureFilter(), minimum, maximum, ownerChooses)
        {
        }

        public TapChoiceEffect(int minimum, int maximum, bool ownerChooses, CardFilter filter) : base(filter, minimum, maximum, ownerChooses) { }

        public TapChoiceEffect(TapChoiceEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new TapChoiceEffect(this);
        }

        protected override void Apply(Game game, Ability source, IEnumerable<Card> cards)
        {
            game.GetPlayer(source.Owner).Tap(game, cards.ToArray());
        }

        public override string ToString()
        {
            if (ControllerChooses)
            {
                return $"Choose {GetAmountAsText()} {Filter} and tap them.";
            }
            else
            {
                return $"Your opponents chooses {GetAmountAsText()} {Filter} and taps them.";
            }
        }
    }
}