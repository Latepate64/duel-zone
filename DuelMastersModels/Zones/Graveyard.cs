﻿using DuelMastersModels.Cards;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// A player’s graveyard is their discard pile. Discarded cards, destroyed creatures and spells cast are put in their owner's graveyard.
    /// </summary>
    public class Graveyard : Zone<IGraveyardCard>
    {
        internal override bool Public { get; } = true;
        internal override bool Ordered { get; } = false;

        public override void Add(IGraveyardCard card)
        {
            _cards.Add(card);
        }

        public override void Remove(IGraveyardCard card)
        {
            _ = _cards.Remove(card);
        }
    }
}