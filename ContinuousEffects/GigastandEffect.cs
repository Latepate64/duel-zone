using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class GigastandEffect : DestructionReplacementEffect
{
    public GigastandEffect() : base()
    {
    }

    public GigastandEffect(GigastandEffect effect) : base(effect)
    {
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }

    public override IContinuousEffect Copy()
    {
        return new GigastandEffect(this);
    }

    public override string ToString()
    {
        return "When this creature would be destroyed, you may return it to your hand instead. If you do, discard a card from your hand.";
    }

    protected override bool Applies(ICreature card, IGame game)
    {
        return IsSourceOfAbility(card);
    }
}
