using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects;

public class DrawCardEffect : OneShotEffect
{
    public DrawCardEffect()
    {
    }

    public DrawCardEffect(DrawCardEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        Controller.DrawCards(1, game, Ability);
    }

    public override IOneShotEffect Copy()
    {
        return new DrawCardEffect(this);
    }

    public override string ToString()
    {
        return "Draw a card.";
    }
}
