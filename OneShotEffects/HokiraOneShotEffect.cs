using ContinuousEffects;
using Interfaces;

namespace OneShotEffects;

public sealed class HokiraOneShotEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(Ability, new HokiraContinuousEffect(Controller.ChooseRace(ToString())));
    }

    public override IOneShotEffect Copy()
    {
        return new HokiraOneShotEffect();
    }

    public override string ToString()
    {
        return "Choose a race. Whenever one of your creatures of that race would be destroyed this turn, return it to your hand instead.";
    }
}
