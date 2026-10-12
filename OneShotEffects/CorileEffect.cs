using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Choose one of your opponent's creatures in the battle zone and put it on top
/// of his deck.
/// </summary>
public sealed class CorileEffect : CardMovingChoiceEffect<ICreature>
{
    private readonly ICardFilter filter;

    public CorileEffect(ICardFilter filter) : base(
        1, 1, true, ZoneType.BattleZone, ZoneType.Deck)
    {
        this.filter = filter;
    }

    CorileEffect(CorileEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new CorileEffect(this);
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetOpponentsChoosableCreatures(
            Applier, filter, game);
    }
}
