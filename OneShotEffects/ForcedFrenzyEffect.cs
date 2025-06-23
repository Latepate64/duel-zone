using ContinuousEffects;
using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class ForcedFrenzyEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(Ability, new ForcedFrenzyContinuousEffect(GetOpponent(game)));
    }

    public override IOneShotEffect Copy()
    {
        return new ForcedFrenzyEffect();
    }

    public override string ToString()
    {
        return "Each of your opponent's creatures gets \"This creature attacks if able\" until the start of your next turn.";
    }
}
