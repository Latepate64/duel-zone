using ContinuousEffects;
using Engine.GameEvents;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Linq;

namespace Cards.DM09;

public sealed class KaluteEffect : DestructionReplacementEffect
{
    readonly string name;

    public KaluteEffect(string name)
    {
        this.name = name;
    }

    public KaluteEffect(KaluteEffect effect) : base(effect)
    {
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        return new CardMovedEvent(gameEvent as ICardMovedEvent)
        {
            Destination = ZoneType.Hand
        };
    }

    public override IContinuousEffect Copy()
    {
        return new KaluteEffect(this);
    }

    public override string ToString()
    {
        return $"When this creature would be destroyed, if another {name} is in the battle zone, return this creature to your hand instead.";
    }

    protected override bool Applies(ICreature card, IGame game)
    {
        return IsSourceOfAbility(card) && game.BattleZone.GetOtherCreatures(card.Id).Any(x => x.Name == name);
    }
}
