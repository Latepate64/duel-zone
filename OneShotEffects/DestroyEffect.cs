using Interfaces;

namespace OneShotEffects;

public sealed class DestroyEffect : CardMovingChoiceEffect<ICreature>
{
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
            filter,
            ZoneType.BattleZone,
            ZoneType.Graveyard)
    {
        this.selectionRange = selectionRange;
    }

    DestroyEffect(DestroyEffect effect) : base(effect)
    {
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
