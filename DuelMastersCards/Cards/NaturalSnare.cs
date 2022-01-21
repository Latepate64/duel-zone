﻿using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class NaturalSnare : Spell
    {
        public NaturalSnare() : base("Natural Snare", 6, Civilization.Nature)
        {
            ShieldTrigger = true;
            // Choose one of your opponent's creatures in the battle zone and put it into his mana zone.
            Abilities.Add(new SpellAbility(new CardMovingEffect(DuelMastersModels.Zones.ZoneType.BattleZone, DuelMastersModels.Zones.ZoneType.ManaZone, 1, 1, true, new OpponentsChoosableCreatureFilter())));
        }
    }
}
