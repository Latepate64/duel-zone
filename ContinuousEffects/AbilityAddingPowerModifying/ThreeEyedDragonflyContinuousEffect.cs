using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAddingPowerModifying;

/// <summary>
/// This creature gets +x power and has "double breaker" until the end of the
/// turn.
/// </summary>
public sealed class ThreeEyedDragonflyContinuousEffect : GetPowerAndDoubleBreakerUntilTheEndOfTheTurnEffect
{
    private readonly ICreature _card;

    public ThreeEyedDragonflyContinuousEffect(int power, ICreature card) : base(
        power)
    {
        _card = card;
    }

    public ThreeEyedDragonflyContinuousEffect(
        ThreeEyedDragonflyContinuousEffect effect) : base(effect)
    {
        _card = effect._card;
    }

    public override IContinuousEffect Copy()
    {
        return new ThreeEyedDragonflyContinuousEffect(this);
    }

    protected override List<ICreature> GetAffectedCards(IGame game)
    {
        return [_card];
    }
}
