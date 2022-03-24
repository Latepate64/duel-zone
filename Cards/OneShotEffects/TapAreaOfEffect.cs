using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    class TapAreaOfEffect : OneShotEffect
    {
        public ICardFilter Filter { get; }

        public TapAreaOfEffect(ICardFilter filter)
        {
            Filter = filter;
        }

        public TapAreaOfEffect(TapAreaOfEffect effect)
        {
            Filter = effect.Filter.Copy();
        }

        public override IOneShotEffect Copy()
        {
            return new TapAreaOfEffect(this);
        }

        public override object Apply(IGame game, IAbility source)
        {
            var cards = game.GetAllCards(Filter, source.Owner).ToArray();
            game.GetPlayer(source.Owner).Tap(game, cards);
            return cards.Any();
        }

        public override string ToString()
        {
            return $"Tap {Filter}.";
        }
    }
}
