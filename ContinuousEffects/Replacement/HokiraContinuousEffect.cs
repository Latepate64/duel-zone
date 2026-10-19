using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.Replacement;

public sealed class HokiraContinuousEffect : WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect
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

    public override string ToString()
    {
        return $"Whenever one of your {_race}s would be destroyed this turn, return it to your hand instead.";
    }

    protected override bool Applies(ICreature card, IGame game)
    {
        return card.Owner == Controller && card.HasRace(_race);
    }
}
