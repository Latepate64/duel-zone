using Engine.Abilities;

namespace OneShotEffects;

public class MutualSingleManaSacrificeEffect : MutualManaSacrificeEffect
{
    public MutualSingleManaSacrificeEffect() : base(1)
    {
    }

    public MutualSingleManaSacrificeEffect(MutualManaSacrificeEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new MutualSingleManaSacrificeEffect(this);
    }
}
