using ContinuousEffects;
using Engine.GameEvents;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM06;

public sealed class LuGilaEffect : ReplacementEffect
{
    public LuGilaEffect()
    {
    }

    public LuGilaEffect(LuGilaEffect effect) : base(effect)
    {
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        return new CardMovedEvent(gameEvent as ICardMovedEvent)
        {
            Destination = ZoneType.BattleZone,
            EntersTapped = true,
        };
    }

    public override bool CanBeApplied(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is ICardMovedEvent e && e.Destination == ZoneType.BattleZone
            && game.GetCard(e.CardInSourceZone) is ICreature creature && creature.IsEvolutionCreature;
    }

    public override IContinuousEffect Copy()
    {
        return new LuGilaEffect(this);
    }

    public override string ToString()
    {
        return "Evolution creatures are put into the battle zone tapped.";
    }
}
