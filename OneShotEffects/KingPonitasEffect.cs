using Interfaces;

namespace OneShotEffects;

public sealed class KingPonitasEffect : SearchEffect
{
    public KingPonitasEffect() : base(true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new KingPonitasEffect();
    }

    public override string ToString()
    {
        return "Search your deck. You may take a water card from your deck, show that card to your opponent, and put it into your hand. Then shuffle your deck.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return Controller.Deck.GetCards(Civilization.Water);
    }
}
