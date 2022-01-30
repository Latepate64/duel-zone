﻿using Cards.StaticAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM01
{
    public class EmeraldGrass : Creature
    {
        public EmeraldGrass() : base("Emerald Grass", 2, Civilization.Light, 3000, Subtype.StarlightTree)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
