using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    public class OpponentRandomDiscardEffect : OneShotEffect
    {
        public OpponentRandomDiscardEffect()
        {
        }

        public OpponentRandomDiscardEffect(OneShotEffect effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new OpponentRandomDiscardEffect(this);
        }

        public override void Apply(Game game, Ability source)
        {
            game.GetOpponent(game.GetPlayer(source.Owner)).DiscardAtRandom(game);
        }

        public override string ToString()
        {
            return "your opponent discards a card at random from his hand.";
        }
    }
}
