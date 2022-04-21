using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class ReturnUpToCardsFromYourManaZoneToYourHandEffect : SelfManaRecoveryEffect
    {
        private readonly int _amount;

        public ReturnUpToCardsFromYourManaZoneToYourHandEffect(int amount) : base(0, amount, true)
        {
            _amount = amount;
        }

        public ReturnUpToCardsFromYourManaZoneToYourHandEffect(ReturnUpToCardsFromYourManaZoneToYourHandEffect effect) : base(effect)
        {
            _amount = effect._amount;
        }

        public override IOneShotEffect Copy()
        {
            return new ReturnUpToCardsFromYourManaZoneToYourHandEffect(this);
        }

        public override string ToString()
        {
            return $"Return up to {_amount} cards from your mana zone to your hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return Controller.ManaZone.Cards;
        }
    }
}
