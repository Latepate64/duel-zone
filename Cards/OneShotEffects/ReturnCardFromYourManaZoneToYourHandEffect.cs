using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class ReturnCardFromYourManaZoneToYourHandEffect : SelfManaRecoveryEffect
    {
        public ReturnCardFromYourManaZoneToYourHandEffect() : base(1, 1, true)
        {
        }

        public ReturnCardFromYourManaZoneToYourHandEffect(SelfManaRecoveryEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ReturnCardFromYourManaZoneToYourHandEffect(this);
        }

        public override string ToString()
        {
            return "Return a card from your mana zone to your hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return GetController(game).ManaZone.Cards;
        }
    }
}
