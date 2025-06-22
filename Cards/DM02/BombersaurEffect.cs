using OneShotEffects;
using Engine.Abilities;

namespace Cards.DM02;

public class BombersaurEffect : MutualManaSacrificeEffect
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
