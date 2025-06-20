using Engine;
using Engine.GameEvents;

namespace ContinuousEffects;

public abstract class DestructionReplacementEffect : ReplacementEffect
{
    protected DestructionReplacementEffect() : base()
    {
    }

    protected DestructionReplacementEffect(DestructionReplacementEffect effect) : base(effect)
    {
    }

    public override bool CanBeApplied(IGameEvent gameEvent, IGame game)
    {
        if (gameEvent is CardMovedEvent e)
        {
            return e.Source == ZoneType.BattleZone && e.Destination == ZoneType.Graveyard && Applies(game.GetCard(e.CardInSourceZone) as Creature, game);
        }
        return false;
    }

    protected abstract bool Applies(Creature creature, IGame game);
}
