using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.PowerModifying;

/// <summary>
/// While attacking, this creature gets +x power for each other creature in the
/// battle zone.
/// </summary>
public sealed class WhileAttackingThisCreatureGetPowerForEachOtherCreatureInTheBattleZone
    : PowerAttackerMultiplierEffect
{
    private readonly ICardFilter filter;

    public WhileAttackingThisCreatureGetPowerForEachOtherCreatureInTheBattleZone(
        int power, ICardFilter filter) : base(power)
    {
        this.filter = filter;
    }

    public WhileAttackingThisCreatureGetPowerForEachOtherCreatureInTheBattleZone(
        WhileAttackingThisCreatureGetPowerForEachOtherCreatureInTheBattleZone
            effect) : base(effect)
    {
        filter = effect.filter;
    }

    public override IContinuousEffect Copy()
    {
        return new WhileAttackingThisCreatureGetPowerForEachOtherCreatureInTheBattleZone(
            this);
    }

    protected override int GetMultiplier(IGame game)
    {
        return game.BattleZone.GetNumberOfOtherCreatures(
            (ICreature)Source!, filter);
    }
}
