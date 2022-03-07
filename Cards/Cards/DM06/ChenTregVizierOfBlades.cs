﻿using Common;

namespace Cards.Cards.DM06
{
    class ChenTregVizierOfBlades : Creature
    {
        public ChenTregVizierOfBlades() : base("Chen Treg, Vizier of Blades", 5, 2000, Subtype.Initiate, Civilization.Light)
        {
            AddAbilities(new Engine.Abilities.TapAbility(new OneShotEffects.TapChoiceEffect(1, 1, true)));
        }
    }
}