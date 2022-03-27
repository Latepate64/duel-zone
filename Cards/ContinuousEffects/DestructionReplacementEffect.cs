using Common;
using Common.GameEvents;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    abstract class DestructionReplacementEffect : ReplacementEffect
    {
        protected DestructionReplacementEffect(CardFilter filter) : base(new CardMovedEvent { Source = ZoneType.BattleZone, Destination = ZoneType.Graveyard }, filter)
        {
        }

        protected DestructionReplacementEffect(ReplacementEffect effect) : base(effect)
        {
        }

        public override bool Replaceable(IGameEvent gameEvent, IGame game)
        {
            if (gameEvent is CardMovedEvent e)
            {
                return e.Source == ZoneType.BattleZone && e.Destination == ZoneType.Graveyard && Filter.Applies(game.GetCard(e.CardInSourceZone), game, game.GetPlayer(e.Player.Id));
            }
            return false;
        }
    }
}
