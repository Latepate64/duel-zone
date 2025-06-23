using Interfaces;

namespace OneShotEffects;

public sealed class RouletteOfRuinEffect : OneShotEffect
{
    public RouletteOfRuinEffect()
    {
    }

    public RouletteOfRuinEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var number = Controller.ChooseNumber(new Engine.Choices.NumberChoice(Controller, ToString()));
        foreach (var player in new System.Guid[] { Ability.Controller.Id, game.GetOpponent(Ability.Controller.Id) })
        {
            game.GetPlayer(player).ShowCardsToOpponent(game, [.. game.GetPlayer(player).Hand.Cards]);
            game.Move(
                Ability, ZoneType.Hand, ZoneType.Graveyard, [.. game.GetPlayer(player).Hand.CardsWithManaCost(number)]);
            game.GetPlayer(player).Unreveal([.. game.GetPlayer(player).Hand.Cards]);
        }
    }

    public override IOneShotEffect Copy()
    {
        return new RouletteOfRuinEffect(this);
    }

    public override string ToString()
    {
        return "Choose a number. Show your hand to your opponent and discard from it each card that has that cost. Then your opponent shows you his hand and discards from it each card that has that cost.";
    }
}
