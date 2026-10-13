using Interfaces;

namespace OneShotEffects;

public sealed class BounceEffect : CardMovingChoiceEffect<ICreature>
{
    private readonly SelectionRange selectionRange;

    public BounceEffect(
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
            ZoneType.Hand)
    {
        this.selectionRange = selectionRange;
    }

    BounceEffect(BounceEffect effect) : base(effect)
    {
        selectionRange = effect.selectionRange;
    }

    public override IOneShotEffect Copy()
    {
        return new BounceEffect(this);
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreatures(
            Applier, filter, game, selectionRange);
    }
}
