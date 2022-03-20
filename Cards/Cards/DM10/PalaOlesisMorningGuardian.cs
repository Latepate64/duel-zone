﻿using Cards.CardFilters;
using Cards.StaticAbilities;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;

namespace Cards.Cards.DM10
{
    class PalaOlesisMorningGuardian : Creature
    {
        public PalaOlesisMorningGuardian() : base("Pala Olesis, Morning Guardian", 3, 2500, Common.Subtype.Guardian, Common.Civilization.Light)
        {
            AddAbilities(new BlockerAbility(), new PalaOlesisMorningGuardianAbility(), new CannotAttackPlayersAbility());
        }
    }

    class PalaOlesisMorningGuardianAbility : StaticAbility
    {
        public PalaOlesisMorningGuardianAbility() : base(new PowerModifyingEffect(2000, new OwnersBattleZoneCreatureExceptFilter(), new Indefinite(), new Conditions.ItIsYourOpponentsTurnCondition()))
        {
        }

        public override string ToString()
        {
            return "During your opponent's turn, each of your other creatures gets +2000 power.";
        }
    }
}
