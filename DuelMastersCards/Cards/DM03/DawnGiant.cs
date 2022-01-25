﻿using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM03
{
    class DawnGiant : Creature
    {
        public DawnGiant() : base("Dawn Giant", 7, Civilization.Nature, 11000, Subtype.Giant)
        {
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}