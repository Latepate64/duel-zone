using Engine.Abilities;
using Interfaces;

namespace Cards.DM12;

public sealed class NecrodragonZalvaEffect : OneShotEffect
{
    public NecrodragonZalvaEffect()
    {
    }

    public NecrodragonZalvaEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        GetOpponent(game).DrawCards(1, game, Ability);
    }

    public override IOneShotEffect Copy()
    {
        return new NecrodragonZalvaEffect(this);
    }

    public override string ToString()
    {
        return "Your opponent draws a card.";
    }
}
