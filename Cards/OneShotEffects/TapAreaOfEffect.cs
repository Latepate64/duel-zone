using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    abstract class TapAreaOfEffect : OneShotEffect
    {
        public ICardFilter Filter { get; }

        protected TapAreaOfEffect(ICardFilter filter)
        {
            Filter = filter;
        }

        protected TapAreaOfEffect(TapAreaOfEffect effect)
        {
            Filter = effect.Filter.Copy();
        }

        public override object Apply(IGame game, IAbility source)
        {
            var cards = game.GetAllCards(Filter, source.Controller).ToArray();
            game.GetPlayer(source.Controller).Tap(game, cards);
            return cards.Any();
        }
    }
}
