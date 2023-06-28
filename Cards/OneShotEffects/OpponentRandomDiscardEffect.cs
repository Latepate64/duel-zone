using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    abstract class OpponentRandomDiscardEffect : OneShotEffect
    {
        public int Amount { get; set; }

        protected OpponentRandomDiscardEffect(int amount)
        {
            Amount = amount;
        }

        protected OpponentRandomDiscardEffect(OpponentRandomDiscardEffect effect)
        {
            Amount = effect.Amount;
        }

        public override void Apply(IGame game)
        {
            Applier.Opponent.DiscardAtRandom(Amount, Ability);
        }

        public override string ToString()
        {
            return $"Your opponent discards {(Amount == 1 ? "a card" : $"{Amount} cards")} at random from his hand.";
        }
    }

    class OpponentDiscardsCardAtRandomEffect : OpponentRandomDiscardEffect
    {
        public OpponentDiscardsCardAtRandomEffect() : base(1)
        {
        }

        public OpponentDiscardsCardAtRandomEffect(OpponentRandomDiscardEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new OpponentDiscardsCardAtRandomEffect(this);
        }
    }
}
