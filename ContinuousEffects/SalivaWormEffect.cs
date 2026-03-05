using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class SalivaWormEffect : StealthEffect, IPowerModifyingEffect
{
    public SalivaWormEffect(Civilization civilization = Civilization.Darkness) : base(civilization)
    {
    }

    public SalivaWormEffect(StealthEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new SalivaWormEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        (Source as ICreature).IncreasePower(4000);
    }

    public override string ToString()
    {
        return $"This creature gets +4000 power and has \"{Civilization} stealth\"";
    }
}
