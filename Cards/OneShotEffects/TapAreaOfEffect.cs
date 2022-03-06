using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    class TapAreaOfEffect : OneShotEffect
    {
        public CardFilter Filter { get; }

        public TapAreaOfEffect(CardFilter filter)
        {
            Filter = filter;
        }

        public TapAreaOfEffect(TapAreaOfEffect effect)
        {
            Filter = effect.Filter.Copy();
        }

        public override OneShotEffect Copy()
        {
            return new TapAreaOfEffect(this);
        }

        public override void Apply(Game game, Ability source)
        {
            game.GetPlayer(source.Owner).Tap(game, game.GetAllCards(Filter, source.Owner).ToArray());
        }

        public override string ToString()
        {
            return $"Tap {Filter}.";
        }
    }
}
