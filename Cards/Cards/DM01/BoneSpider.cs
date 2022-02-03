﻿using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Engine;
using Engine.Zones;

namespace Cards.Cards.DM01
{
    class BoneSpider : Creature
    {
        public BoneSpider() : base("Bone Spider", 3, Civilization.Darkness, 5000, Subtype.LivingDead)
        {
            // When this creature wins a battle, destroy it.
            var targetFilter = new TargetFilter();
            Abilities.Add(new WinBattleAbility(new CardMovingAreaOfEffect(ZoneType.BattleZone, ZoneType.Graveyard, targetFilter), targetFilter));
        }
    }
}