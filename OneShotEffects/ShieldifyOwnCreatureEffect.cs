using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Add one of your creatures from the battle zone to your shields face down.
/// </summary>
public sealed class ShieldifyOwnCreatureEffect
    : CardMovingChoiceEffect<ICreature>
{
    private readonly ICardFilter filter;

    public ShieldifyOwnCreatureEffect(ICardFilter filter) : base(
        1, 1, true, ZoneType.BattleZone, ZoneType.ShieldZone)
    {
        this.filter = filter;
    }

    public ShieldifyOwnCreatureEffect(
        ShieldifyOwnCreatureEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
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
