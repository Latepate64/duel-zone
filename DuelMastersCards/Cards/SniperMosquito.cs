﻿using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class SniperMosquito : Creature
    {
        public SniperMosquito() : base("Sniper Mosquito", 1, Civilization.Nature, 2000, Subtype.GiantInsect)
        {
            // Whenever this creature attacks, return a card from your mana zone to your hand.
            Abilities.Add(new WheneverThisCreatureAttacksAbility(new ManaRecoveryEffect(new OwnersManaZoneCardFilter(), 1, 1, true)));
        }
    }
}
