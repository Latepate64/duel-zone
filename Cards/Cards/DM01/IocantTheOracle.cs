﻿using Cards.StaticAbilities;
using Common;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class IocantTheOracle : Creature
    {
        public IocantTheOracle() : base("Iocant, the Oracle", 2, 2000, Common.Subtype.LightBringer, Common.Civilization.Light)
        {
            AddAbilities(new BlockerAbility(), new IocantTheOracleAbility(), new CannotAttackPlayersAbility());
        }
    }

    class IocantTheOracleAbility : StaticAbility
    {
        public IocantTheOracleAbility() : base(new PowerModifyingEffect(2000, new Conditions.HaveAtLeastOneSubtypeCreatureInTheBattleZoneCondition(Subtype.AngelCommand)))
        {
        }

        public override string ToString()
        {
            return "While you have at least 1 Angel Command in the battle zone, this creature gets +2000 power.";
        }
    }
}
