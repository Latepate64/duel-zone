using Interfaces;

namespace OneShotEffects;

public sealed class OpponentRandomDiscardEffect : OneShotEffect
{
    public int Amount { get; set; }

    public OpponentRandomDiscardEffect(int amount = 1)
    {
        Amount = amount;
    }

    OpponentRandomDiscardEffect(OpponentRandomDiscardEffect effect)
    {
        Amount = effect.Amount;
    }

    public override void Apply(IGame game)
    {
        GetOpponent(game).DiscardAtRandom(game, Amount, Ability);
    }

    public override string ToString()
    {
        return $"Your opponent discards {(Amount == 1 ? "a card" : $"{Amount} cards")} at random from his hand.";
    }

    public override IOneShotEffect Copy()
    {
        return new OpponentRandomDiscardEffect(this);
    }
}
