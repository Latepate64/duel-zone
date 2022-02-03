﻿using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    class MaskedHorrorShadowOfScorn : Creature
    {
        public MaskedHorrorShadowOfScorn() : base("Masked Horror, Shadow of Scorn", 5, Civilization.Darkness, 1000, Subtype.Ghost)
        {
            // When you put this creature into the battle zone, your opponent discards a card at random from his hand.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentRandomDiscardEffect()));
        }
    }
}