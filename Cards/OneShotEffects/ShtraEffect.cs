using Cards.CardFilters;
using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ShtraEffect : OneShotEffect
    {
        public int Amount { get; }

        public ShtraEffect(int amount)
        {
            Amount = amount;
        }

        public ShtraEffect(ShtraEffect effect)
        {
            Amount = effect.Amount;
        }

        public override void Apply(Game game, Ability source)
        {
            new ManaRecoveryEffect(new OwnersManaZoneCardFilter(), Amount, Amount, true).Apply(game, source);
            new ManaRecoveryEffect(new OpponentsManaZoneCardFilter(), Amount, Amount, false).Apply(game, source);
        }

        public override OneShotEffect Copy()
        {
            return new ShtraEffect(this);
        }

        public override string ToString()
        {
            return $"Return ${Amount} cards from your mana zone to your hand. Then your opponent chooses ${Amount} cards in his mana zone and returns them to his hand.";
        }
    }
}