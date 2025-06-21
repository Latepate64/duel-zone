using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect : UntilEndOfTurnEffect, IPowerModifyingEffect
{
    private readonly int _power;
    private readonly ICreature[] _cards;

    public ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect effect) : base(effect)
    {
        _power = effect._power;
        _cards = effect._cards;
    }

    public ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(int power, params ICreature[] cards) : base()
    {
        _power = power;
        _cards = cards;
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        _cards.ToList().ForEach(x => x.IncreasePower(_power));
    }

    public override string ToString()
    {
        return $"This creature has +{_power} power until the end of the turn.";
    }
}
