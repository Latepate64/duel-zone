using Interfaces;

namespace OneShotEffects;

public sealed class InvincibleTechnologyEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        var cards = Controller.Deck.Cards;
        var selectedCards = Controller.ChooseAnyNumberOfCards(cards, ToString()).ToArray();
        Controller.ShowCardsToOpponent(game, selectedCards);
        game.Move(Ability, ZoneType.Deck, ZoneType.Hand, selectedCards);
        Controller.ShuffleOwnDeck(game);
    }

    public override IOneShotEffect Copy()
    {
        return new InvincibleTechnologyEffect();
    }

    public override string ToString()
    {
        return "Search your deck. You may take any number of cards from your deck, show those cards to your opponent, and put them into your hand. Then shuffle your deck.";
    }
}
