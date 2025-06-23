using Interfaces;

namespace OneShotEffects;

public sealed class RainOfArrowsEffect : OneShotEffect
{
    public RainOfArrowsEffect()
    {
    }

    public RainOfArrowsEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var cards = GetOpponent(game).Hand.Cards.ToArray();
        if (cards.Any())
        {
            Controller.Look(GetOpponent(game), game, cards);
            GetOpponent(game).Discard(Ability, game, [.. cards.Where(x => x.HasCivilization(Civilization.Darkness)
                && x is ISpell)]);
            GetOpponent(game).Unreveal(cards);
        }
    }

    public override IOneShotEffect Copy()
    {
        return new RainOfArrowsEffect(this);
    }

    public override string ToString()
    {
        return "Look at your opponent's hand. He discards all darkness spells from it.";
    }
}
