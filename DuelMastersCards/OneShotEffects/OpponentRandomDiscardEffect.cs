using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.OneShotEffects
{
    public class OpponentRandomDiscardEffect : OneShotEffect
    {
        public OpponentRandomDiscardEffect()
        {
        }

        public OpponentRandomDiscardEffect(OneShotEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new OpponentRandomDiscardEffect(this);
        }

        public override void Apply(Duel duel)
        {
            duel.GetOpponent(duel.GetPlayer(Controller)).DiscardAtRandom(duel);
        }
    }
}
