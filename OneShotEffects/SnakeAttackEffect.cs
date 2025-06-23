using ContinuousEffects;
using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class SnakeAttackEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(Ability, new ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect(
            [.. game.BattleZone.GetCreatures(Ability.Controller.Id)]));
    }

    public override IOneShotEffect Copy()
    {
        return new SnakeAttackEffect();
    }

    public override string ToString()
    {
        return "Each of your creatures in the battle zone gets \"double breaker\" until the end of the turn.";
    }
}
