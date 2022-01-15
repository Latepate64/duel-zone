﻿using DuelMastersCards.Resolvables;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class Teleportation : Spell
    {
        public Teleportation() : base("Teleportation", 5, Civilization.Water)
        {
            Abilities.Add(new SpellAbility(new AquaSurferResolvable(2)));
        }
    }
}