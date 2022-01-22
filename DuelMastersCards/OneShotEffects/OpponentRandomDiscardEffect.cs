using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.OneShotEffects
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
    }
}
