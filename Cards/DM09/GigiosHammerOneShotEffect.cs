using Engine.Abilities;
using Interfaces;

namespace Cards.DM09;

public class GigiosHammerOneShotEffect : OneShotEffect
{
    public GigiosHammerOneShotEffect()
    {
    }

    public GigiosHammerOneShotEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(Ability, new GigiosHammerContinuousEffect(Controller.ChooseRace(ToString())));
    }

    public override IOneShotEffect Copy()
    {
        return new GigiosHammerOneShotEffect(this);
    }

    public override string ToString()
    {
        return "Choose a race. Each creature of that race attacks this turn if able and gets \"power attacker +4000\" until the end of the turn.";
    }
}
