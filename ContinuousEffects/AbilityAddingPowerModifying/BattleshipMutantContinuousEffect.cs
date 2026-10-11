using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAddingPowerModifying;

/// <summary>
/// Until the end of the turn, each of your darkness creatures in the battle
/// zone gets +x power and "double breaker."
/// </summary>
public sealed class BattleshipMutantContinuousEffect
    : GetPowerAndDoubleBreakerUntilTheEndOfTheTurnEffect
{
    private readonly ICardFilter filter;

    public BattleshipMutantContinuousEffect(
        int power, ICardFilter filter) : base(power)
    {
        this.filter = filter;
    }

    public BattleshipMutantContinuousEffect(
        BattleshipMutantContinuousEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IContinuousEffect Copy()
    {
        return new BattleshipMutantContinuousEffect(this);
    }

    protected override List<ICreature> GetAffectedCards(IGame game)
    {
        return [.. game.BattleZone.GetCreaturesControlledByPlayer(
            Applier, filter)];
    }
}
