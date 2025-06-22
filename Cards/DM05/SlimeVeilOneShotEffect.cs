using Engine.Abilities;
using Interfaces;

namespace Cards.DM05;

public sealed class SlimeVeilOneShotEffect : OneShotEffect
{
    public SlimeVeilOneShotEffect()
    {
    }

    public SlimeVeilOneShotEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(Ability, new SlimeVeilContinuousEffect(GetOpponent(game)));
    }

    public override IOneShotEffect Copy()
    {
        return new SlimeVeilOneShotEffect(this);
    }

    public override string ToString()
    {
        return "During your opponent's next turn, each of his creatures attacks if able.";
    }
}
