﻿using Common;

namespace Cards.Cards.DM06
{
    class Aeropica : Creature
    {
        public Aeropica() : base("Aeropica", 7, 4000, Subtype.SeaHacker, Civilization.Water)
        {
            AddTapAbility(new OneShotEffects.ChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect());
        }
    }
}
