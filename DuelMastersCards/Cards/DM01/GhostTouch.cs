﻿using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards.DM01
{
    public class GhostTouch : Spell
    {
        public GhostTouch() : base("Ghost Touch", 2, Civilization.Darkness)
        {
            ShieldTrigger = true;
            // Your opponent discards a card at random from his hand.
            Abilities.Add(new SpellAbility(new OpponentRandomDiscardEffect()));
        }
    }
}