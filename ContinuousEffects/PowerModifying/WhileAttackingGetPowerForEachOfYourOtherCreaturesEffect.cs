using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.PowerModifying;

/// <summary>
/// While attacking, this creature gets +x power for each other creature you
/// have in the battle zone.
/// </summary>
public sealed class WhileAttackingGetPowerForEachOfYourOtherCreaturesEffect
    : PowerAttackerMultiplierEffect
{
    private readonly ICardFilter filter;

    public WhileAttackingGetPowerForEachOfYourOtherCreaturesEffect(
        int power, ICardFilter filter) : base(power)
    {
        this.filter = filter;
    }

    public WhileAttackingGetPowerForEachOfYourOtherCreaturesEffect(
        WhileAttackingGetPowerForEachOfYourOtherCreaturesEffect effect) : base(
        effect)
    {
        filter = effect.filter.Copy();
    }

    public override IContinuousEffect Copy()
    {
        return new WhileAttackingGetPowerForEachOfYourOtherCreaturesEffect(
            this);
    }

    protected override int GetMultiplier(IGame game)
    {
        return game.BattleZone.GetNumberOfOtherCreaturesControllerByPlayer(
            (ICreature)Source!, filter);
    }
}
