﻿using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class GatlingSkyterror : Creature
    {
        public GatlingSkyterror() : base("Gatling Skyterror", 7, 7000, Common.Subtype.ArmoredWyvern, Common.Civilization.Fire)
        {
            AddAbilities(new ThisCreatureCanAttackUntappedCreaturesAbility());
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
