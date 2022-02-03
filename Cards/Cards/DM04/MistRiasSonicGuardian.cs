﻿using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Engine;

namespace Cards.Cards.DM04
{
    public class MistRiasSonicGuardian : Creature
    {
        public MistRiasSonicGuardian() : base("Mist Rias, Sonic Guardian", 5, Civilization.Light, 2000, Subtype.Guardian)
        {
            // Whenever another creature is put into the battle zone, you may draw a card.
            Abilities.Add(new AnotherCreaturePutIntoBattleZoneAbility(new ControllerMayDrawCardsEffect(1)));
        }
    }
}