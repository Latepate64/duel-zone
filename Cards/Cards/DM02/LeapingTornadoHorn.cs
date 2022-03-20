﻿using Common;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class LeapingTornadoHorn : Creature
    {
        public LeapingTornadoHorn() : base("Leaping Tornado Horn", 3, 2000, Subtype.HornedBeast, Civilization.Nature)
        {
            AddAbilities(new LeapingTornadoHornAbility());
        }
    }

    class LeapingTornadoHornAbility : StaticAbility
    {
        public LeapingTornadoHornAbility() : base(new ContinuousEffects.PowerAttackerMultiplierEffect(1000, new CardFilters.OwnersBattleZoneCreatureExceptFilter()))
        {
        }

        public override string ToString()
        {
            return "While attacking, this creature gets +1000 power for each other creature you have in the battle zone.";
        }
    }
}
