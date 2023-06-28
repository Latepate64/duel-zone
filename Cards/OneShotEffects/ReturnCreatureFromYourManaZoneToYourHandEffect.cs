using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class ReturnCreatureFromYourManaZoneToYourHandEffect : SelfManaRecoveryEffect
    {
        public ReturnCreatureFromYourManaZoneToYourHandEffect() : base(1, 1, true)
        {
        }

        public ReturnCreatureFromYourManaZoneToYourHandEffect(SelfManaRecoveryEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ReturnCreatureFromYourManaZoneToYourHandEffect(this);
        }

        public override string ToString()
        {
            return "Return a creature from your mana zone to your hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IAbility source)
        {
            return Applier.ManaZone.Creatures;
        }
    }
}
