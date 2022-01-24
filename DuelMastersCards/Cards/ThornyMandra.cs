﻿using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;
using DuelMastersModels.Zones;

namespace DuelMastersCards.Cards
{
    public class ThornyMandra : Creature
    {
        public ThornyMandra() : base("Thorny Mandra", 5, Civilization.Nature, 4000, Subtype.TreeFolk)
        {
            // When you put this creature into the battle zone, you may put 1 creature from your graveyard into your mana zone.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CardMovingChoiceEffect(new OwnersGraveyardCreatureFilter(), 0, 1, true, ZoneType.Graveyard, ZoneType.ManaZone)));
        }
    }
}
