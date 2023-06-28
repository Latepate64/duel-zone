using Engine;
using Engine.GameEvents;

namespace Cards.ContinuousEffects
{
    abstract class DestructionReplacementEffect : ReplacementEffect
    {
        protected DestructionReplacementEffect() : base()
        {
        }

        protected DestructionReplacementEffect(DestructionReplacementEffect effect) : base(effect)
        {
        }

        public override bool CanBeApplied(IGameEvent gameEvent)
        {
            if (gameEvent is CardMovedEvent e)
            {
                return e.Source == ZoneType.BattleZone && e.Destination == ZoneType.Graveyard && Applies(Game.GetCard(e.CardInSourceZone));
            }
            return false;
        }

        protected abstract bool Applies(ICard card);
    }
}
