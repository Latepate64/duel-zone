using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class MutualManaRecoveryEffect : OneShotEffect
    {
        public int Amount { get; }

        public MutualManaRecoveryEffect(int amount)
        {
            Amount = amount;
        }

        public MutualManaRecoveryEffect(MutualManaRecoveryEffect effect)
        {
            Amount = effect.Amount;
        }

        public override object Apply(IGame game, IAbility source)
        {
            foreach (var effect in new OneShotEffect[] { new ReturnCardsFromYourManaZoneToYourHandEffect(Amount), new MutualManaRecovery2Effect(Amount) })
            {
                effect.Apply(game, source);
            }
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new MutualManaRecoveryEffect(this);
        }

        public override string ToString()
        {
            var cards = Amount > 1 ? $"{Amount} cards" : "a card";
            return $"Return {cards} from your mana zone to your hand. Then your opponent chooses {cards} in his mana zone and returns {(Amount > 1 ? "them" : "it")} to his hand.";
        }
    }

    class MutualManaRecovery2Effect : OpponentManaRecoveryEffect
    {
        public MutualManaRecovery2Effect(MutualManaRecovery2Effect effect) : base(effect)
        {
        }

        public MutualManaRecovery2Effect(int amount) : base(amount, amount, false)
        {
            Amount = amount;
        }

        public int Amount { get; }

        public override IOneShotEffect Copy()
        {
            return new MutualManaRecovery2Effect(this);
        }

        public override string ToString()
        {
           return $"Your opponent chooses {(Amount > 1 ? $"{Amount} cards" : "a card")} in his mana zone and returns {(Amount > 1 ? "them" : "it")} to his hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return source.GetOpponent(game).ManaZone.Cards;
        }
    }
}