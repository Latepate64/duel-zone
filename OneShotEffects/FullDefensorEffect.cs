using ContinuousEffects;
using Interfaces;

namespace OneShotEffects;

public sealed class FullDefensorEffect : OneShotEffect
{
    public FullDefensorEffect() : base()
    {
    }

    public FullDefensorEffect(FullDefensorEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(Ability, new FullDefensorContinuousEffect(
            Ability.Controller.Id, [.. game.BattleZone.GetCreatures(Ability.Controller.Id)]));
    }

    public override IOneShotEffect Copy()
    {
        return new FullDefensorEffect(this);
    }

    public override string ToString()
    {
        return "Until the start of your next turn, each of your creatures in the battle zone gets \"Blocker\".";
    }
}
