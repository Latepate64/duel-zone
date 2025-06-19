using Engine;
using Engine.Abilities;

namespace Effects.OneShot;

public class NeveTheLevelerEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        Controller.SearchOwnDeck();
        Controller.TakeCreaturesFromOwnDeckShowThemToOpponentAndPutThemIntoOwnHand(
            0, game.GetAmountOfBattleZoneCreatures(GetOpponent(game)) - game.GetAmountOfBattleZoneCreatures(Controller),
            ToString(), game, Ability);
        Controller.ShuffleOwnDeck(game);
    }

    public override IOneShotEffect Copy()
    {
        return new NeveTheLevelerEffect();
    }

    public override string ToString()
    {
        return "Search your deck. For each extra creature he has, you may take a creature from your deck, show that creature to your opponent, and put it into your hand. Then shuffle your deck.";
    }
}
