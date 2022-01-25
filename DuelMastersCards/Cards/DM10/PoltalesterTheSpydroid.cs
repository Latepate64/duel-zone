﻿using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM10
{
    public class PoltalesterTheSpydroid : Creature
    {
        public PoltalesterTheSpydroid() : base("Poltalester, the Spydroid", 5, Civilization.Light, 2000, Subtype.Soltrooper)
        {
            ShieldTrigger = true;
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}