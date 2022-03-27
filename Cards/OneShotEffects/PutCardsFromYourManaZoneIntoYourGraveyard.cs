﻿using Cards.CardFilters;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class PutCardsFromYourManaZoneIntoYourGraveyard : ManaBurnEffect
    {
        private readonly int _amount;

        public PutCardsFromYourManaZoneIntoYourGraveyard(int amount) : base(new OwnersManaZoneCardFilter(), amount, amount, true)
        {
            _amount = amount;
        }

        public PutCardsFromYourManaZoneIntoYourGraveyard(PutCardsFromYourManaZoneIntoYourGraveyard effect) : base(effect)
        {
            _amount = effect._amount;
        }

        public override IOneShotEffect Copy()
        {
            return new PutCardsFromYourManaZoneIntoYourGraveyard(this);
        }

        public override string ToString()
        {
            return $"Put {(_amount > 1 ? $"{_amount} cards" : "a card")} from your mana zone into your graveyard.";
        }
    }
}