﻿using Common;
using Common.GameEvents;
using Engine;

namespace Cards.ContinuousEffects
{
    abstract class DestructionReplacementEffect : ReplacementEffect
    {
        protected DestructionReplacementEffect() : base(new CardMovedEvent { Source = ZoneType.BattleZone, Destination = ZoneType.Graveyard })
        {
        }

        protected DestructionReplacementEffect(DestructionReplacementEffect effect) : base(effect)
        {
        }

        public override bool Replaceable(IGameEvent gameEvent, IGame game)
        {
            if (gameEvent is CardMovedEvent e)
            {
                return e.Source == ZoneType.BattleZone && e.Destination == ZoneType.Graveyard && Applies(game.GetCard(e.CardInSourceZone), game);
            }
            return false;
        }

        protected abstract bool Applies(Engine.ICard card, IGame game);
    }
}
