using ContinuousEffects;
using Engine;
using Engine.GameEvents;
using Engine.Steps;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM09;

public class HokiraContinuousEffect : WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect, IExpirable
{
    private readonly Race _race;

    public HokiraContinuousEffect(Race race) : base()
    {
        _race = race;
    }

    public HokiraContinuousEffect(HokiraContinuousEffect effect) : base(effect)
    {
        _race = effect._race;
    }

    public override IContinuousEffect Copy()
    {
        return new HokiraContinuousEffect(this);
    }

    public bool ShouldExpire(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
    }

    public override string ToString()
    {
        return $"Whenever one of your {_race}s would be destroyed this turn, return it to your hand instead.";
    }

    protected override bool Applies(ICreature card, IGame game)
    {
        return card.Owner == Controller && card.HasRace(_race);
    }
}
