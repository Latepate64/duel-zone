﻿using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    class BoneAssassinTheRipper : Creature
    {
        public BoneAssassinTheRipper() : base("Bone Assassin, the Ripper", 4, Civilization.Darkness, 2000, Subtype.LivingDead)
        {
            Abilities.Add(new SlayerAbility());
        }
    }
}
