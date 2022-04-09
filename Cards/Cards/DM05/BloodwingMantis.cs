﻿using Common;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM05
{
    class BloodwingMantis : Creature
    {
        public BloodwingMantis() : base("Bloodwing Mantis", 5, 6000, Subtype.GiantInsect, Civilization.Nature)
        {
            AddWheneverThisCreatureAttacksAbility(new BloodwingMantisEffect());
            AddDoubleBreakerAbility();
        }
    }

    class BloodwingMantisEffect : OneShotEffects.SelfManaRecoveryEffect
    {
        public BloodwingMantisEffect() : base(2, 2, true, new CardFilters.OwnersManaZoneCreatureFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new BloodwingMantisEffect();
        }

        public override string ToString()
        {
            return "Return 2 creatures from your mana zone to your hand.";
        }

        protected override IEnumerable<Engine.ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.GetPlayer(source.Controller).ManaZone.Creatures;
        }
    }
}
