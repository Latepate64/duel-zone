using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    abstract class OneShotAreaOfEffect : OneShotEffect
    {
        public CardFilter Filter { get; }

        protected OneShotAreaOfEffect(CardFilter filter)
        {
            Filter = filter;
        }

        protected OneShotAreaOfEffect(OneShotAreaOfEffect effect)
        {
            Filter = effect.Filter.Copy();
        }

        protected IEnumerable<Card> GetAffectedCards(Game game, Ability source)
        {
            return game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetPlayer(source.Owner)));
        }
    }
}
