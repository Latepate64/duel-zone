using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects;

public class DrawTwoCardsEffect : OneShotEffect
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
