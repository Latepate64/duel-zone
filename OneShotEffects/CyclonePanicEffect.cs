using Interfaces;

namespace OneShotEffects;

public sealed class CyclonePanicEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        game.Players.ToList().ForEach(x => Apply(x, game, Ability));
    }

    private static void Apply(IPlayer player, IGame game, IAbility source)
    {
        var amount = player.Hand.Size;
        game.Move(source, ZoneType.Hand, ZoneType.Deck, [.. player.Hand.Cards]);
        player.ShuffleOwnDeck(game);
        player.DrawCards(amount, game, source);
    }

    public override IOneShotEffect Copy()
    {
        return new CyclonePanicEffect();
    }

    public override string ToString()
    {
        return "Each player counts the cards in his hand, shuffles these cards into his deck, then draws that many cards.";
    }
}
