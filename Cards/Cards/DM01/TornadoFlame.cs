﻿using Cards.CardFilters;
using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    public class TornadoFlame : Spell
    {
        public TornadoFlame() : base("Tornado Flame", 5, Civilization.Fire)
        {
            ShieldTrigger = true;
            // Destroy 1 of your opponent's creatures that has power 4000 or less.
            Abilities.Add(new SpellAbility(new DestroyEffect(new OpponentsBattleZoneChoosableMaxPowerCreatureFilter(4000), 1, 1, true)));
        }
    }
}