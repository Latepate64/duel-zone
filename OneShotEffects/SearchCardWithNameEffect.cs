using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class SearchCardWithNameEffect : SearchEffect
{
    readonly string _name;

    SearchCardWithNameEffect(SearchCardWithNameEffect effect) : base(effect)
    {
        _name = effect._name;
    }

    public SearchCardWithNameEffect(string name) : base(true)
    {
        _name = name;
    }

    public override string ToString()
    {
        return $"Search your deck. You may take a {_name} from your deck, show that card to your opponent, and put it into your hand. Then shuffle your deck.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return Controller.Deck.CardsWithName(_name);
    }

    public override IOneShotEffect Copy()
    {
        return new SearchCardWithNameEffect(this);
    }
}
