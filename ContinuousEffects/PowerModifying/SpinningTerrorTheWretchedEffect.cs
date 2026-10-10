using CardFilters;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.PowerModifying;

/// <summary>
/// This creature gets +x power for each tapped creature your opponent has in
/// the battle zone.
/// </summary>
public sealed class SpinningTerrorTheWretchedEffect :
    PowerModifyingMultiplierEffect
{
    private readonly ICardFilter filter = new TappedCreatureFilter();

    public SpinningTerrorTheWretchedEffect(int power) : base(power)
    {
    }

    public SpinningTerrorTheWretchedEffect(
        SpinningTerrorTheWretchedEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IContinuousEffect Copy()
    {
        return new SpinningTerrorTheWretchedEffect(this);
    }

    protected override int GetMultiplier(IGame game)
    {
        return game.BattleZone.GetNumberOfCreaturesControllerByPlayer(
            Applier.Opponent, filter);
    }
}
