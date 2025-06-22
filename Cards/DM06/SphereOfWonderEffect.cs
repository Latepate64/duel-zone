using Engine.Abilities;
using Interfaces;

namespace Cards.DM06;

public sealed class SphereOfWonderEffect : OneShotEffect
{
    public SphereOfWonderEffect()
    {
    }

    public SphereOfWonderEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        if (GetOpponent(game).ShieldZone.Size > Controller.ShieldZone.Size)
        {
            Controller.PutFromTopOfDeckIntoShieldZone(1, game, Ability);
        }
    }

    public override IOneShotEffect Copy()
    {
        return new SphereOfWonderEffect(this);
    }

    public override string ToString()
    {
        return "If your opponent has more shields than you do, add the top card of your deck to your shields face down.";
    }
}
