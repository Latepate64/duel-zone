using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class MummyWrapShadowOfFatigueEffect : OneShotEffect
{
    public MummyWrapShadowOfFatigueEffect()
    {
    }

    public MummyWrapShadowOfFatigueEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        game.Players.ToList().ForEach(x => x.DiscardAtRandom(game, 1, Ability));
    }

    public override IOneShotEffect Copy()
    {
        return new MummyWrapShadowOfFatigueEffect(this);
    }

    public override string ToString()
    {
        return "Each player discards a card at random from his hand.";
    }
}
