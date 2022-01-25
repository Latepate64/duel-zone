﻿using DuelMastersModels;

namespace DuelMastersCards.Cards.DM03
{
    class BonePiercer : Creature
    {
        public BonePiercer() : base("Bone Piercer", 2, Civilization.Darkness, 1000, Subtype.BrainJacker)
        {
            // When this creature is put into your graveyard from the battle zone, you may return a creature from your mana zone to your hand.
            Abilities.Add(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ManaRecoveryEffect(new CardFilters.OwnersManaZoneCreatureFilter(), 0, 1, true)));
        }
    }
}