﻿using Cards.CardFilters;
using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    public class CrystalMemory : Spell
    {
        public CrystalMemory() : base("Crystal Memory", 4, Common.Civilization.Water)
        {
            ShieldTrigger = true;
            // Search your deck. You may take a card from your deck and put it into your hand. Then shuffle your deck.
            Abilities.Add(new SpellAbility(new SearchDeckEffect(new OwnersDeckCardFilter(), false)));
        }
    }
}
