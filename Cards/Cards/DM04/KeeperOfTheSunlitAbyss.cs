﻿using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class KeeperOfTheSunlitAbyss : Creature
    {
        public KeeperOfTheSunlitAbyss() : base("Keeper of the Sunlit Abyss", 4, 1000, Subtype.CyberVirus, Civilization.Water)
        {
            AddAbilities(new KeeperOfTheSunlitAbyssAbility());
        }
    }

    class KeeperOfTheSunlitAbyssAbility : Engine.Abilities.StaticAbility
    {
        public KeeperOfTheSunlitAbyssAbility() : base(new KeeperOfTheSunlitAbyssEffect())
        {
        }
    }

    class KeeperOfTheSunlitAbyssEffect : PowerModifyingEffect
    {
        public KeeperOfTheSunlitAbyssEffect() : base(1000, new CardFilters.BattleZoneCivilizationCreatureFilter(Civilization.Light, Civilization.Darkness), new Engine.Durations.Indefinite()) { }
    }
}