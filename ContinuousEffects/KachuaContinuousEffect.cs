using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class KachuaContinuousEffect : ContinuousEffect, ISpeedAttackerEffect, ICardAffectable
{
    public KachuaContinuousEffect(ICard card)
    {
        Card = card;
    }

    public KachuaContinuousEffect(KachuaContinuousEffect effect) : base(effect)
    {
        Card = effect.Card;
    }

    public ICard Card { get; }

    public bool Applies(ICreature creature, IGame game)
    {
        return creature == Card;
    }

    public override IContinuousEffect Copy()
    {
        return new KachuaContinuousEffect(this);
    }

    public override string ToString()
    {
        return $"{Card} has \"speed attacker.\"";
    }
}
