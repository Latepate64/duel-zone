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
            new SelfManaRecoveryEffect(Amount, Amount, true, Common.CardType.Any).Apply(game, source);
            new OpponentManaRecoveryEffect(Amount, Amount, false).Apply(game, source);
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