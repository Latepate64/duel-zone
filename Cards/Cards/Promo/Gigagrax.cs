﻿using Common;

namespace Cards.Cards.Promo
{
    class Gigagrax : Creature
    {
        public Gigagrax() : base("Gigagrax", 8, 5000, Subtype.Chimera, Civilization.Darkness)
        {
            AddAbilities(new TriggeredAbilities.DestroyedAbility(new OneShotEffects.DestroyEffect(new CardFilters.OpponentsBattleZoneChoosableCreatureFilter(), 0, 1, true)));
        }
    }
}