﻿using Engine;
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

        public override bool CanBeApplied(IGameEvent gameEvent, IGame game)
        {
            if (gameEvent is CardMovedEvent e)
            {
                return e.Source == ZoneType.BattleZone && e.Destination == ZoneType.Graveyard && Applies(game.GetCard(e.CardInSourceZone), game);
            }
            return false;
        }

        protected abstract bool Applies(ICard card, IGame game);
    }
}
