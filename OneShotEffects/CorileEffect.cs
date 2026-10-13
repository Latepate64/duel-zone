using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Choose one of your opponent's creatures in the battle zone and put it on top
/// of his deck.
/// </summary>
public sealed class CorileEffect : CardMovingChoiceEffect<ICreature>
{
    public CorileEffect(ICardFilter filter) : base(
        1, 1, true, filter, ZoneType.BattleZone, ZoneType.Deck)
    {
    }

    CorileEffect(CorileEffect effect) : base(effect)
    {
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
