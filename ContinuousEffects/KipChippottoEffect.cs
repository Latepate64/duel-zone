using ContinuousEffects;
using Engine.GameEvents;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class KipChippottoEffect : DestructionReplacementEffect
{
    public KipChippottoEffect()
    {
    }

    public KipChippottoEffect(KipChippottoEffect effect) : base(effect)
    {
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        if (Controller.ChooseToTakeAction(ToString()))
        {
            return new CardMovedEvent(gameEvent as ICardMovedEvent)
            {
                CardInSourceZone = Source.Id
            };
        }
        else
        {
            return gameEvent;
        }
    }

    public override IContinuousEffect Copy()
    {
        return new KipChippottoEffect(this);
    }

    public override string ToString()
    {
        return "When one of your Armored Dragons would be destroyed, you may destroy this creature instead.";
    }

    protected override bool Applies(ICreature card, IGame game)
    {
        return card != null && card.Owner == Controller && card.HasRace(Race.ArmoredDragon);
    }
}
