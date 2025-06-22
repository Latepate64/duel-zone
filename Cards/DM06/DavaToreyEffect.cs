using ContinuousEffects;
using Engine.GameEvents;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM06;

public sealed class DavaToreyEffect : MadnessEffect
{
    public DavaToreyEffect()
    {
    }

    public DavaToreyEffect(DavaToreyEffect effect) : base(effect)
    {
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        return new CardMovedEvent(gameEvent as ICardMovedEvent)
        {
            Destination = ZoneType.BattleZone
        };
    }

    public override IContinuousEffect Copy()
    {
        return new DavaToreyEffect(this);
    }

    public override string ToString()
    {
        return "During your opponent's turn, if this creature would be discarded from your hand, put it into the battle zone instead.";
    }
}
