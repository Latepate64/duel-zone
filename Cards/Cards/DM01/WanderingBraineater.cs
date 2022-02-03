﻿using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    public class WanderingBraineater : Creature
    {
        public WanderingBraineater() : base("Wandering Braineater", 2, Civilization.Darkness, 2000, Subtype.LivingDead)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}