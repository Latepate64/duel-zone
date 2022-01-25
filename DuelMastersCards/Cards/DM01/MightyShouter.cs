﻿using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM01
{
    public class MightyShouter : Creature
    {
        public MightyShouter() : base("Mighty Shouter", 3, Civilization.Nature, 2000, Subtype.BeastFolk)
        {
            // When this creature would be destroyed, put it into your mana zone instead.
            Abilities.Add(new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadAbility());
        }
    }
}
