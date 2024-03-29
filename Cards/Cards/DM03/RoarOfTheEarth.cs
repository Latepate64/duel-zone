﻿using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM03
{
    class RoarOfTheEarth : Spell
    {
        public RoarOfTheEarth() : base("Roar of the Earth", 2, Civilization.Nature)
        {
            AddShieldTrigger();
            AddSpellAbilities(new RoarOfTheEarthEffect());
        }
    }

    class RoarOfTheEarthEffect : OneShotEffects.SelfManaRecoveryEffect
    {
        public RoarOfTheEarthEffect() : base(1, 1, true) { }

        public RoarOfTheEarthEffect(SelfManaRecoveryEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new RoarOfTheEarthEffect(this);
        }

        public override string ToString()
        {
            return "Return a creature that costs 6 or more from your mana zone to your hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return Controller.ManaZone.Creatures.Where(x => x.ManaCost >= 6);
        }
    }
}
