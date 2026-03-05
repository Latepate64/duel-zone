using ContinuousEffects;
using Interfaces;

namespace OneShotEffects;

public sealed class InvincibleUnityOneShotEffect : OneShotEffect
{
    public InvincibleUnityOneShotEffect()
    {
    }

    public InvincibleUnityOneShotEffect(InvincibleUnityOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(Ability, new InvincibleUnityContinuousEffect(game.BattleZone.GetCreatures(
            Ability.Controller.Id)));
    }

    public override IOneShotEffect Copy()
    {
        return new InvincibleUnityOneShotEffect(this);
    }

    public override string ToString()
    {
        return "Each of your creatures in the battle zone gets +8000 power and \"triple breaker\" until the end of the turn.";
    }
}
