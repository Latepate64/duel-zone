﻿using DuelMastersModels;
using DuelMastersModels.Zones;

namespace DuelMastersCards.OneShotEffects
{
    class ShieldBurnEffect : CardMovingChoiceEffect
    {
        public ShieldBurnEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses, ZoneType.ShieldZone, ZoneType.Graveyard)
        {
        }
    }
}