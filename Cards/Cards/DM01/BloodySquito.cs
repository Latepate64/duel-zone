﻿using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Cards.TriggeredAbilities;
using Common;

namespace Cards.Cards.DM01
{
    class BloodySquito : Creature
    {
        public BloodySquito() : base("Bloody Squito", 2, Common.Civilization.Darkness, 4000, Common.Subtype.BrainJacker)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());

            // When this creature wins a battle, destroy it.
            var targetFilter = new TargetFilter();
            Abilities.Add(new WinBattleAbility(new CardMovingAreaOfEffect(ZoneType.BattleZone, ZoneType.Graveyard, targetFilter), targetFilter));
        }
    }
}
