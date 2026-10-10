using CardFilters;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.PowerModifying;

/// <summary>
/// This creature gets +x power for each of your other untapped creatures in the
/// battle zone.
/// </summary>
public sealed class ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures :
    PowerModifyingMultiplierEffect
{
    private readonly ICardFilter filter = new UntappedCreatureFilter();

    public ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures(
        int power) : base(power)
    {
    }

    public ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures(
        ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures effect) : base(
            effect)
    {
        filter = effect.filter.Copy();
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures(
            this);
    }

    protected override int GetMultiplier(IGame game)
    {
        return game.BattleZone.GetNumberOfOtherCreaturesControllerByPlayer(
            (ICreature)Source!, filter);
    }
}
