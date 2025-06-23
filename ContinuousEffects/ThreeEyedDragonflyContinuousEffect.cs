using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class ThreeEyedDragonflyContinuousEffect : GetPowerAndDoubleBreakerUntilTheEndOfTheTurnEffect
{
    private readonly ICreature _card;

    public ThreeEyedDragonflyContinuousEffect(ThreeEyedDragonflyContinuousEffect effect) : base(effect)
    {
        _card = effect._card;
    }

    public ThreeEyedDragonflyContinuousEffect(ICreature card) : base(2000)
    {
        _card = card;
    }

    public override IContinuousEffect Copy()
    {
        return new ThreeEyedDragonflyContinuousEffect(this);
    }

    public override string ToString()
    {
        return "This creature gets +2000 power and has \"double breaker\" until the end of the turn.";
    }

    protected override List<ICreature> GetAffectedCards(IGame game)
    {
        return [_card];
    }
}
