using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.Replacement;

public sealed class MihailCelestialElementalEffect : DestructionReplacementEffect
{
    public MihailCelestialElementalEffect() : base()
    {
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }

    public override IContinuousEffect Copy()
    {
        return new MihailCelestialElementalEffect();
    }

    public override string ToString()
    {
        return "Whenever another creature would be destroyed, it stays in the battle zone instead.";
    }

    protected override bool Applies(ICreature card, IGame game)
    {
        return !IsSourceOfAbility(card);
    }
}
