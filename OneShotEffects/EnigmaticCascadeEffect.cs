using Interfaces;

namespace OneShotEffects;

public sealed class EnigmaticCascadeEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        var player = Controller;
        int amount = player.DiscardAnyNumberOfCards(game, Ability);
        player.DrawCards(amount, game, Ability);
    }

    public override IOneShotEffect Copy()
    {
        return new EnigmaticCascadeEffect();
    }

    public override string ToString()
    {
        return "Discard any number of cards from your hand. Then draw that many cards.";
    }
}
