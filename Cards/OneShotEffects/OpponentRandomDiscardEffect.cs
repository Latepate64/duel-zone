using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class OpponentRandomDiscardEffect : OneShotEffect
    {
        public int Amount { get; set; }

        public OpponentRandomDiscardEffect(int amount = 1)
        {
            Amount = amount;
        }

        public OpponentRandomDiscardEffect(OpponentRandomDiscardEffect effect)
        {
            Amount = effect.Amount;
        }

        public override IOneShotEffect Copy()
        {
            return new OpponentRandomDiscardEffect(this);
        }

        public override object Apply(IGame game, IAbility source)
        {
            game.GetOpponent(game.GetPlayer(source.Controller)).DiscardAtRandom(game, Amount);
            return null;
        }

        public override string ToString()
        {
            return $"Your opponent discards {(Amount == 1 ? "a card" : $"{Amount} cards")} at random from his hand.";
        }
    }
}
