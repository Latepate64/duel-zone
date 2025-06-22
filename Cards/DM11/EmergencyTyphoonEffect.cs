using Engine.Abilities;
using Interfaces;

namespace Cards.DM11;

public sealed class EmergencyTyphoonEffect : OneShotEffect
{

    public EmergencyTyphoonEffect(EmergencyTyphoonEffect effect) : base(effect)
    {
    }

    public EmergencyTyphoonEffect()
    {
    }

    public override void Apply(IGame game)
    {
        Controller.DrawCardsOptionally(game, Ability, 2);
        Controller.DiscardOwnCards(game, Ability, 1);
    }

    public override IOneShotEffect Copy()
    {
        return new EmergencyTyphoonEffect(this);
    }

    public override string ToString()
    {
        return "Draw up to 2 cards. Then discard a card from your hand.";
    }
}
