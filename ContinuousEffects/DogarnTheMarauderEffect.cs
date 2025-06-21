using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class DogarnTheMarauderEffect : PowerAttackerMultiplierEffect
{
    public DogarnTheMarauderEffect(int power) : base(power)
    {
    }

    public DogarnTheMarauderEffect(DogarnTheMarauderEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new DogarnTheMarauderEffect(this);
    }

    public override string ToString()
    {
        return $"While attacking, this creature gets +{Power} power for each other tapped creature you have in the battle zone.";
    }

    protected override int GetMultiplier(IGame game)
    {
        return game.BattleZone.GetOtherTappedCreatures(Controller.Id, Source.Id).Count();
    }
}
