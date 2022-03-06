﻿using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class BrainSerum : Spell
    {
        public BrainSerum() : base("Brain Serum", 4, Common.Civilization.Water)
        {
            ShieldTrigger = true;

            // Draw up to 2 cards.
            AddAbilities(new SpellAbility(new ControllerMayDrawCardsEffect(2)));
        }
    }
}
