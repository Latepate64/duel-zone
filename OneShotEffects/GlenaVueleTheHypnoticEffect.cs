using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class GlenaVueleTheHypnoticEffect : OneShotEffect
{
    public GlenaVueleTheHypnoticEffect()
    {
    }

    public GlenaVueleTheHypnoticEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        if (Controller.ChooseToTakeAction(ToString()))
        {
            Controller.PutFromTopOfDeckIntoShieldZone(1, game, Ability);
        }
    }

    public override IOneShotEffect Copy()
    {
        return new GlenaVueleTheHypnoticEffect(this);
    }

    public override string ToString()
    {
        return "You may add the top card of your deck to your shields face down.";
    }
}
