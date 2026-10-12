using Interfaces;

namespace OneShotEffects;

public sealed class SearchEffect : SearchAnyDeckEffect
{
    public bool Reveal { get; }
    private readonly ICardFilter filter;

    public SearchEffect(
        bool reveal, ICardFilter filter, int maximum = 1) : base(maximum)
    {
        Reveal = reveal;
        this.filter = filter;
    }

    SearchEffect(SearchEffect effect) : base(effect)
    {
        Reveal = effect.Reveal;
        filter = effect.filter.Copy();
    }

    protected override void Apply(
        IGame game, IAbility source, params ICard[] cards)
    {
        if (Reveal)
        {
            Controller.ShowCardsToOpponent(game, cards);
        }
        game.Move(Ability, ZoneType.Deck, ZoneType.Hand, cards);
        if (Reveal)
        {
            Controller?.Unreveal(cards);
        }
    }

    protected override IEnumerable<ICard> GetAffectedCards(
        IGame game, IAbility source)
    {
        return Controller.Deck.GetCards(filter);
    }

    public override IOneShotEffect Copy()
    {
        return new SearchEffect(this);
    }
}
