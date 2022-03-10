﻿using Common;

namespace Cards.Cards.DM12
{
    class Gigarayze : Creature
    {
        public Gigarayze() : base("Gigarayze", 4, 2000, Subtype.Chimera, Civilization.Darkness)
        {
            AddAbilities(new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.SalvageCreatureEffect(0, 1, Civilization.Water, Civilization.Fire)));
        }
    }
}