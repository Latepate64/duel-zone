using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class DrawTwoCardsEffect : OneShotEffect
{
    public DrawTwoCardsEffect()
    {
    }

    public DrawTwoCardsEffect(DrawTwoCardsEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        Controller.DrawCards(2, game, Ability);
    }

    public override IOneShotEffect Copy()
    {
        return new DrawTwoCardsEffect(this);
    }

    public override string ToString()
    {
        return "Draw 2 cards.";
    }
}
