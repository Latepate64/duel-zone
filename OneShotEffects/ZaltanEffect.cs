using Interfaces;

namespace OneShotEffects;

/// <summary>
/// You may discard up to 2 cards from your hand. For each card you discard,
/// choose a creature in the battle zone and return it to its owner's hand.
/// </summary>
public sealed class ZaltanEffect : OneShotEffect
{
    private readonly ICardFilter filter;

    public ZaltanEffect(ICardFilter filter)
    {
        this.filter = filter;
    }

    public ZaltanEffect(ZaltanEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override void Apply(IGame game)
    {
        var player = Controller;
        var cards = player.ChooseCards(player.Hand.Cards, 0, 2, ToString());
        game.Move(Ability, ZoneType.Hand, ZoneType.Graveyard, [.. cards]);
        var creatures = player.ChooseCards(
            game.BattleZone.GetChoosableCreatures(Applier, filter, game),
            cards.Count(), cards.Count(), ToString());
        game.Move(Ability, ZoneType.BattleZone, ZoneType.Hand, [.. creatures]);
    }

    public override IOneShotEffect Copy()
    {
        return new ZaltanEffect(this);
    }
}
