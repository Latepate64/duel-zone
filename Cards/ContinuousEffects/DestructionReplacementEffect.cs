using Common;
using Common.GameEvents;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    abstract class DestructionReplacementEffect : ReplacementEffect
    {
        protected DestructionReplacementEffect(GameEvent eventToReplace) : base(eventToReplace)
        {
        }

        protected DestructionReplacementEffect(ReplacementEffect effect) : base(effect)
        {
        }

        public override bool Replaceable(GameEvent gameEvent, Game game)
        {
            if (gameEvent is CardMovedEvent e)
            {
                return e.Source == ZoneType.BattleZone && e.Destination == ZoneType.Graveyard && Filter.Applies(game.GetCard(e.CardInSourceZone), game, game.GetPlayer(e.Player.Id));
            }
            return false;
        }

        public override string ToString()
        {
            return $"When {Filter} would be destroyed, ";
        }
    }
}
