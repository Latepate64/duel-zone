using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.PowerModifying;

/// <summary>
/// This creature gets +x power for each creature your opponent has in the
/// battle zone.
/// </summary>
public sealed class ThisCreatureGetPowerForEachCreatureYourOpponentControls :
    PowerModifyingMultiplierEffect
{
    private readonly ICardFilter filter;

    public ThisCreatureGetPowerForEachCreatureYourOpponentControls(
        int power, ICardFilter filter)
        : base(power)
    {
        this.filter = filter;
    }

    public ThisCreatureGetPowerForEachCreatureYourOpponentControls(
        ThisCreatureGetPowerForEachCreatureYourOpponentControls effect) : base(
            effect)
    {
        filter = effect.filter.Copy();
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureGetPowerForEachCreatureYourOpponentControls(
            this);
    }

    protected override int GetMultiplier(IGame game)
    {
        return game.BattleZone.GetNumberOfCreaturesControllerByPlayer(
            Applier.Opponent, filter);
    }
}
