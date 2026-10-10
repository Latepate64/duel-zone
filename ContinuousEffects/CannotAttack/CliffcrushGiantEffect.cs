using CardFilters;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.CannotAttack;

/// <summary>
/// While you have any other untapped creatures in the battle zone, this
/// creature can't attack.
/// </summary>
public sealed class CliffcrushGiantEffect : ContinuousEffect, ICannotAttackEffect
{
    private readonly ICardFilter filter = new UntappedCreatureFilter();

    public CliffcrushGiantEffect()
    {
    }

    public CliffcrushGiantEffect(CliffcrushGiantEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public bool CannotAttack(ICreature creature, IGame game)
    {
        if (!IsSourceOfAbility(creature)) return false;
        if (!game.BattleZone.HasOtherCreaturesControllerByPlayer(
            creature, filter)) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new CliffcrushGiantEffect(this);
    }
}
