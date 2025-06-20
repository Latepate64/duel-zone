using Engine;
using Engine.Abilities;

namespace OneShotEffects;

public abstract class SearchCardWithNameEffect : SearchEffect
{
    private readonly string _name;

    protected SearchCardWithNameEffect(SearchCardWithNameEffect effect) : base(effect)
    {
        _name = effect._name;
    }

    protected SearchCardWithNameEffect(string name) : base(true)
    {
        _name = name;
    }

    public override string ToString()
    {
        return $"Search your deck. You may take a {_name} from your deck, show that card to your opponent, and put it into your hand. Then shuffle your deck.";
    }

    protected override IEnumerable<Card> GetAffectedCards(IGame game, IAbility source)
    {
        return Controller.Deck.CardsWithName(_name);
    }
}
