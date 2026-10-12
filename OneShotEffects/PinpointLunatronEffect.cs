using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Choose a creature in the battle zone or a card in either player's mana zone
/// and return it to its owner's hand.
/// </summary>
public sealed class PinpointLunatronEffect : CardSelectionEffect<ICard>
{
    private readonly ICardFilter filter;

    public PinpointLunatronEffect(ICardFilter filter) : base(1, 1, true)
    {
        this.filter = filter;
    }

    public PinpointLunatronEffect(PinpointLunatronEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new PinpointLunatronEffect(this);
    }

    protected override void Apply(
        IGame game, IAbility source, params ICard[] cards)
    {
        foreach (var card in cards)
        {
            var sourceZone = game.BattleZone.Cards.Contains(card)
                ? ZoneType.BattleZone : ZoneType.ManaZone;
            game.Move(Ability, sourceZone, ZoneType.Hand, card);
        }
    }

    protected override IEnumerable<ICard> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.Players.SelectMany(x => x.ManaZone.Cards).Union(
            game.BattleZone.GetChoosableCreatures(Applier, filter, game));
    }
}
