using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class RainbowStoneEffect : SearchAnyDeckEffect
{
    public RainbowStoneEffect() : base()
    {
    }

    public RainbowStoneEffect(SearchAnyDeckEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new RainbowStoneEffect(this);
    }

    public override string ToString()
    {
        return "Search your deck. You may take a card from your deck and put it into your mana zone. Then shuffle your deck.";
    }

    protected override void Apply(IGame game, IAbility source, params ICard[] cards)
    {
        game.Move(Ability, ZoneType.Deck, ZoneType.ManaZone, cards);
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return Controller.Deck.Cards;
    }
}
