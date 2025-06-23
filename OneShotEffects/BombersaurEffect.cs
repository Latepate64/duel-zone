using Engine.Abilities;

namespace OneShotEffects;

public sealed class BombersaurEffect : MutualManaSacrificeEffect
{
    public BombersaurEffect() : base(2)
    {
    }

    public BombersaurEffect(BombersaurEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new BombersaurEffect(this);
    }
}
