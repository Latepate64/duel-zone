using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.PowerModifying;

/// <summary>
/// This creature gets +x power for each of your other creatures in the battle
/// zone.
/// </summary>
public sealed class ThisCreatureGetsPowerForEachOfYourOtherCreatures :
    PowerModifyingMultiplierEffect
{
    private readonly ICardFilter filter;

    public ThisCreatureGetsPowerForEachOfYourOtherCreatures(
        int power, ICardFilter filter) : base(power)
    {
        this.filter = filter.Copy();
    }

    public ThisCreatureGetsPowerForEachOfYourOtherCreatures(
        ThisCreatureGetsPowerForEachOfYourOtherCreatures effect) : base(
            effect)
    {
        filter = effect.filter.Copy();
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureGetsPowerForEachOfYourOtherCreatures(
            this);
    }

    protected override int GetMultiplier(IGame game)
    {
        return game.BattleZone.GetNumberOfOtherCreaturesControllerByPlayer(
            (ICreature)Source!, filter);
    }
}
