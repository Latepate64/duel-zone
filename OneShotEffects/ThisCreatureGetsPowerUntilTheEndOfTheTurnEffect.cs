using ContinuousEffects;
using Interfaces;

namespace OneShotEffects;

public sealed class ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect : OneShotEffect, IPowerable
{
    public int Power { get; }

    public ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(int power)
    {
        Power = power;
    }

    public ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect effect) :
        base(effect)
    {
        Power = effect.Power;
    }

    public override IOneShotEffect Copy()
    {
        return new ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(this);
    }

    public override void Apply(IGame game)
    {
        throw new NotImplementedException();
        // game.AddContinuousEffects(Ability, new ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(
        //     Power, Ability.Source as ICreature));
    }

    public override string ToString()
    {
        return $"This creature gets +{Power} power until the end of the turn.";
    }
}
