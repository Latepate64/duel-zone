using Interfaces;

namespace OneShotEffects;

public sealed class DestroyEffect : CardMovingChoiceEffect<ICreature>
{
    private readonly ICardFilter filter;
    private readonly SelectionRange selectionRange;

    public DestroyEffect(
        int minimum,
        int maximum,
        bool controllerChooses,
        ICardFilter filter,
        SelectionRange selectionRange) : base(
            minimum,
            maximum,
            controllerChooses,
            ZoneType.BattleZone,
            ZoneType.Graveyard)
    {
        this.filter = filter;
        this.selectionRange = selectionRange;
    }

    DestroyEffect(DestroyEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
        selectionRange = effect.selectionRange;
    }

    public override IOneShotEffect Copy()
    {
        return new DestroyEffect(this);
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreatures(
            Applier, filter, game, selectionRange);
    }
}
