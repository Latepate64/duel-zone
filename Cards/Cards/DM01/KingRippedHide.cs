﻿using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class KingRippedHide : Creature
    {
        public KingRippedHide() : base("King Ripped-Hide", 7, 5000, Common.Subtype.Leviathan, Common.Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayDrawCardsEffect(2));
        }
    }
}
