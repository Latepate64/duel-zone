using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Add one of your creatures from the battle zone to your shields face down.
/// </summary>
public sealed class ShieldifyOwnCreatureEffect
    : CardMovingChoiceEffect
{
    public ShieldifyOwnCreatureEffect(ICardFilter filter, SelectionRange selectionRange) : base(
        1, 1, true, filter, ZoneType.BattleZone, ZoneType.ShieldZone, selectionRange)
    {
    }

    public ShieldifyOwnCreatureEffect(
        ShieldifyOwnCreatureEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ShieldifyOwnCreatureEffect(this);
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetCreaturesControlledByPlayer(Applier, filter);
    }
}
