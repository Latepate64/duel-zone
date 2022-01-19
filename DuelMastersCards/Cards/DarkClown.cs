﻿using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.StaticAbilities;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class DarkClown : Creature
    {
        public DarkClown() : base("Dark Clown", 4, Civilization.Darkness, 6000, Subtype.BrainJacker)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
            var targetFilter = new TargetFilter();
            Abilities.Add(new WinBattleAbility(new DestroyCreaturesEffect(targetFilter), targetFilter));
        }
    }
}
