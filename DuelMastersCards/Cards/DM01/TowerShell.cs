﻿using DuelMastersCards.CardFilters;
using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM01
{
    public class TowerShell : Creature
    {
        public TowerShell() : base("Tower Shell", 6, Civilization.Nature, 5000, Subtype.ColonyBeetle)
        {
            Abilities.Add(new UnblockableAbility(new BattleZoneMaxPowerCreatureFilter(4000)));
        }
    }
}