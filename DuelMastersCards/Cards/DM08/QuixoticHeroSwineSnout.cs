﻿using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Engine;

namespace Cards.Cards.DM08
{
    public class QuixoticHeroSwineSnout : Creature
    {
        public QuixoticHeroSwineSnout() : base("Quixotic Hero Swine Snout", 2, Civilization.Nature, 1000, Subtype.BeastFolk)
        {
            // Whenever another creature is put into the battle zone, this creature gets +3000 power until the end of the turn.
            Abilities.Add(new AnotherCreaturePutIntoBattleZoneAbility(new QuixoticHeroSwineSnoutEffect()));
        }
    }
}
