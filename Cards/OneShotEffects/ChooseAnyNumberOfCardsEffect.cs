using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    public abstract class ChooseAnyNumberOfCardsEffect : OneShotEffect
    {
        protected ChooseAnyNumberOfCardsEffect()
        {
        }

        protected ChooseAnyNumberOfCardsEffect(ChooseAnyNumberOfCardsEffect effect) : base(effect)
        {
        }

        protected abstract void Apply(IAbility source, params ICard[] cards);

        public override void Apply()
        {
            var cards = GetAffectedCards(Ability);
            if (cards.Any())
            {
                var chosen = Applier.ChooseAnyNumberOfCards(cards, ToString());
                Apply(Ability, chosen.ToArray());
            }
        }

        protected abstract IEnumerable<ICard> GetAffectedCards(IAbility source);
    }
}
