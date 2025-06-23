using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class AquaAgentEffect : DestructionReplacementOptionallyToHandEffect
{
    public AquaAgentEffect() : base() { }


    public override IContinuousEffect Copy()
    {
        return new AquaAgentEffect();
    }

    public override string ToString()
    {
        return "When this creature would be destroyed, you may return it to your hand instead.";
    }

    protected override bool Applies(ICreature card, IGame game)
    {
        return IsSourceOfAbility(card);
    }
}
