using Engine.GameEvents;
using GameEvents;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class GlaisMejiculaEffect : WhenOneOfYourShieldsWouldBeBrokenEffect
{
    public GlaisMejiculaEffect()
    {
    }

    public GlaisMejiculaEffect(WhenOneOfYourShieldsWouldBeBrokenEffect effect) : base(effect)
    {
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        var e = gameEvent as ShieldsBreakEvent;
        var maximum = Controller.Hand.Size / 2;
        var shields = Controller.ChooseCards(e.Shields, 0, maximum, ToString());
        if (shields.Any())
        {
            var toDiscard = Controller.ChooseCards(
                Controller.Hand.Cards, 2 * shields.Count(), 2 * shields.Count(), ToString());
            return new GlaisMejiculaEvent(e.Shields.Where(x => x != shields), toDiscard, Ability);
        }
        else
        {
            return gameEvent;
        }
    }

    public override IContinuousEffect Copy()
    {
        return new GlaisMejiculaEffect(this);
    }

    public override string ToString()
    {
        return "Whenever one of your shields would be broken, you may discard 2 cards from your hand instead.";
    }
}
