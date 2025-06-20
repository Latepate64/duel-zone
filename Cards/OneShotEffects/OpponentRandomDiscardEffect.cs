using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects;

public abstract class OpponentRandomDiscardEffect : OneShotEffect
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
        GetOpponent(game).DiscardAtRandom(game, Amount, Ability);
    }

    public override string ToString()
    {
        return $"Your opponent discards {(Amount == 1 ? "a card" : $"{Amount} cards")} at random from his hand.";
    }
}
