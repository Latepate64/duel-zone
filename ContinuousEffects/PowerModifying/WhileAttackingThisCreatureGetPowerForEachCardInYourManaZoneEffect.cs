using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.PowerModifying;

public sealed class WhileAttackingThisCreatureGetPowerForEachCardInYourManaZoneEffect
    : PowerAttackerMultiplierEffect
{
    private readonly ICardFilter filter;

    public WhileAttackingThisCreatureGetPowerForEachCardInYourManaZoneEffect(
        int power, ICardFilter filter) : base(power)
    {
        this.filter = filter;
    }

    public WhileAttackingThisCreatureGetPowerForEachCardInYourManaZoneEffect(
        WhileAttackingThisCreatureGetPowerForEachCardInYourManaZoneEffect
            effect) : base(effect)
    {
        filter = effect.filter;
    }

    public override IContinuousEffect Copy()
    {
        return new WhileAttackingThisCreatureGetPowerForEachCardInYourManaZoneEffect(this);
    }

    protected override int GetMultiplier(IGame game)
    {
        return Applier.ManaZone.GetNumberOfCards(filter);
    }
}
