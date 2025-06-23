using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM10;

public sealed class RyudmilaChannelerOfSunsEffect : DestructionReplacementEffect
{
    public RyudmilaChannelerOfSunsEffect() : base()
    {
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        return new RyudmilaEvent(Source);
    }

    public override IContinuousEffect Copy()
    {
        return new RyudmilaChannelerOfSunsEffect();
    }

    public override string ToString()
    {
        return "When this creature would be destroyed, shuffle it into your deck instead.";
    }

    protected override bool Applies(ICreature card, IGame game)
    {
        return IsSourceOfAbility(card);
    }
}
