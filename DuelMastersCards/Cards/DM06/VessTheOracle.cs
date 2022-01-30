﻿using Cards.StaticAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM06
{
    public class VessTheOracle : Creature
    {
        public VessTheOracle() : base("Vess, the Oracle", 1, Civilization.Light, 2000, Subtype.LightBringer)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
