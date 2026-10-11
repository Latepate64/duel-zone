using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Mana Feed is a slang term given to the abilities that put creatures or other
/// cards in the battle zone into its owner's mana zone.
/// </summary>
public sealed class ManaFeedEffect : CardMovingChoiceEffect<ICreature>
{
    private readonly ICardFilter filter;
    private readonly SelectionRange selectionRange;

    public ManaFeedEffect(
        int minimum,
        int maximum,
        bool controllerChooses,
        ICardFilter filter,
        SelectionRange selectionRange) : base(
            minimum,
            maximum,
            controllerChooses,
            ZoneType.BattleZone,
            ZoneType.ManaZone)
    {
        this.filter = filter;
        this.selectionRange = selectionRange;
    }

    ManaFeedEffect(ManaFeedEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
        selectionRange = effect.selectionRange;
    }

    public override IOneShotEffect Copy()
    {
        return new ManaFeedEffect(this);
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreatures(
            Applier, filter, game, selectionRange);
    }
}
