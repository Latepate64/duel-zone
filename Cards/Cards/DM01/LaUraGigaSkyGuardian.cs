﻿using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class LaUraGigaSkyGuardian : Creature
    {
        public LaUraGigaSkyGuardian() : base("La Ura Giga, Sky Guardian", 1, 2000, Common.Subtype.Guardian, Common.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddAbilities(new CannotAttackPlayersAbility());
        }
    }
}
