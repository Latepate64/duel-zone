﻿using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class FantasyFish : Creature
    {
        public FantasyFish() : base("Fantasy Fish", 7, Civilization.Water, 2000, Subtype.GelFish)
        {
            ShieldTrigger = true;
            Abilities.Add(new BlockerAbility());
        }
    }
}