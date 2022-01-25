using DuelMastersModels;
using DuelMastersModels.Abilities;
using System.Collections.Generic;

namespace DuelMastersCards.OneShotEffects
{
    class TapChoiceEffect : CardSelectionEffect
    {
        public TapChoiceEffect(CardFilter filter, int minimum, int maximum, bool ownerChooses) : base(filter, minimum, maximum, ownerChooses)
        {
        }

        public TapChoiceEffect(TapChoiceEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new TapChoiceEffect(this);
        }

        protected override void Apply(Game game, Ability source, IEnumerable<Card> cards)
        {
            foreach (var card in cards)
            {
                card.Tapped = true;
            }
        }
    }
}