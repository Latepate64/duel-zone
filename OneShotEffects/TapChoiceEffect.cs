using Interfaces;

namespace OneShotEffects;

public sealed class TapChoiceEffect : CreatureSelectionEffect
{
    private readonly ICardFilter filter;
    private readonly SelectionRange selectionRange;

    public TapChoiceEffect(int minimum, int maximum, bool ownerChooses,
        ICardFilter filter, SelectionRange selectionRange) : base(
            minimum, maximum, ownerChooses)
    {
        this.filter = filter;
        this.selectionRange = selectionRange;
    }

    TapChoiceEffect(TapChoiceEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
        selectionRange = effect.selectionRange;
    }

    protected override void Apply(
        IGame game, IAbility source, params ICreature[] cards)
    {
        (ControllerChooses ? Controller : GetOpponent(game)).Tap(game, cards);
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreatures(
            Applier, filter, game, selectionRange);
    }

    public override IOneShotEffect Copy()
    {
        return new TapChoiceEffect(this);
    }
}
