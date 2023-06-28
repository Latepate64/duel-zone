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

        protected abstract void Apply(IGame game, IAbility source, params ICard[] cards);

        public override void Apply()
        {
            var cards = GetAffectedCards(Game, Ability);
            if (cards.Any())
            {
                var chosen = Applier.ChooseAnyNumberOfCards(cards, ToString());
                Apply(Game, Ability, chosen.ToArray());
            }
        }

        protected abstract IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source);
    }
}
