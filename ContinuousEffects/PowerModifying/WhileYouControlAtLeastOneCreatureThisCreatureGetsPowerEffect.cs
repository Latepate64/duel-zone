using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.PowerModifying;

/// <summary>
/// While you have at least one creature in the battle zone, this creature gets
/// +x power.
/// </summary>
public sealed class WhileYouControlAtLeastOneCreatureThisCreatureGetsPowerEffect
    : ContinuousEffect, IPowerModifyingEffect
{
    private readonly int power;
    private readonly ICardFilter filter;

    public WhileYouControlAtLeastOneCreatureThisCreatureGetsPowerEffect(
        int power, ICardFilter filter) : base()
    {
        this.power = power;
        this.filter = filter;
    }

    public WhileYouControlAtLeastOneCreatureThisCreatureGetsPowerEffect(
        WhileYouControlAtLeastOneCreatureThisCreatureGetsPowerEffect effect)
        : base(effect)
    {
        power = effect.power;
        filter = effect.filter.Copy();
    }

    public override IContinuousEffect Copy()
    {
        return new WhileYouControlAtLeastOneCreatureThisCreatureGetsPowerEffect(
            this);
    }

    public void ModifyPower(IGame game)
    {
        if (game.BattleZone.HasCreaturesControllerByPlayer(Applier, filter))
        {
            ((ICreature)Source!).IncreasePower(power);
        }
    }
}
