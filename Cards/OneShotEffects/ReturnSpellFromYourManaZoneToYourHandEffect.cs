using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class ReturnSpellFromYourManaZoneToYourHandEffect : SelfManaRecoveryEffect
    {
        public ReturnSpellFromYourManaZoneToYourHandEffect() : base(1, 1, true)
        {
        }

        public ReturnSpellFromYourManaZoneToYourHandEffect(SelfManaRecoveryEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ReturnSpellFromYourManaZoneToYourHandEffect(this);
        }

        public override string ToString()
        {
            return "Return a spell from your mana zone to your hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IAbility source)
        {
            return Applier.ManaZone.Spells;
        }
    }
}
