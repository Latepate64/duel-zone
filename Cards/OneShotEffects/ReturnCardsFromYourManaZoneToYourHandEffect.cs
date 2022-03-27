﻿using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ReturnCardsFromYourManaZoneToYourHandEffect : SelfManaRecoveryEffect
    {
        public ReturnCardsFromYourManaZoneToYourHandEffect(int amount) : base(amount, amount, true, new CardFilters.OwnersManaZoneCardFilter())
        {
            Amount = amount;
        }

        public ReturnCardsFromYourManaZoneToYourHandEffect(ReturnCardsFromYourManaZoneToYourHandEffect effect) : base(effect)
        {
            Amount = effect.Amount;
        }

        public int Amount { get; }

        public override IOneShotEffect Copy()
        {
            return new ReturnCardsFromYourManaZoneToYourHandEffect(this);
        }

        public override string ToString()
        {
            return $"Return {(Amount > 1 ? $"{Amount} cards" : "a card")} from your mana zone to your hand.";
        }
    }
}