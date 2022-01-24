﻿using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Zones;

namespace DuelMastersCards.Cards
{
    public class TerrorPit : Spell
    {
        public TerrorPit() : base("Terror Pit", 6, Civilization.Darkness)
        {
            ShieldTrigger = true;
            // Destroy 1 of your opponent's creatures.
            Abilities.Add(new SpellAbility(new CardMovingChoiceEffect(new OpponentsBattleZoneChoosableCreatureFilter(), 1, 1, true, ZoneType.BattleZone, ZoneType.Graveyard)));
        }
    }
}
