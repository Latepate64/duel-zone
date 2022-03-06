﻿using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM08
{
    class QuixoticHeroSwineSnout : Creature
    {
        public QuixoticHeroSwineSnout() : base("Quixotic Hero Swine Snout", 2, 1000, Common.Subtype.BeastFolk, Common.Civilization.Nature)
        {
            // Whenever another creature is put into the battle zone, this creature gets +3000 power until the end of the turn.
            AddAbilities(new PutIntoPlayAbility(new QuixoticHeroSwineSnoutEffect(), new CardFilters.AnotherBattleZoneCreatureFilter()));
        }
    }
}
