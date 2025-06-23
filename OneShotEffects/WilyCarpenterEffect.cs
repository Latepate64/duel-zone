using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class WilyCarpenterEffect : OneShotEffect
{

    public WilyCarpenterEffect(WilyCarpenterEffect effect) : base(effect)
    {
    }

    public WilyCarpenterEffect()
    {
    }

    public override void Apply(IGame game)
    {
        Controller.DrawCardsOptionally(game, Ability, 2);
        Controller.DiscardOwnCards(game, Ability, 2);
    }

    public override IOneShotEffect Copy()
    {
        return new WilyCarpenterEffect(this);
    }

    public override string ToString()
    {
        return "Draw up to 2 cards. Then discard 2 cards from your hand.";
    }
}
