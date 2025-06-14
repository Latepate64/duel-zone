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

        protected abstract void Apply(IGame game, IAbility source, params Card[] cards);

        public override void Apply(IGame game)
        {
            var cards = GetAffectedCards(game, Ability);
            if (cards.Any())
            {
                var chosen = Controller.ChooseAnyNumberOfCards(cards, ToString());
                Apply(game, Ability, [.. chosen]);
            }
        }

        protected abstract IEnumerable<Card> GetAffectedCards(IGame game, IAbility source);
    }
}
