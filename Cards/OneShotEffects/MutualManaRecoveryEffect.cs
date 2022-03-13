using Engine;
using Engine.Abilities;

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

        public override void Apply(Game game, Ability source)
        {
            foreach (var effect in new OneShotEffect[] { new SelfManaRecoveryEffect(Amount, Amount, true, Common.CardType.Any), new OpponentManaRecoveryEffect(Amount, Amount, false)})
            {
                effect.Apply(game, source);
            }
        }

        public override OneShotEffect Copy()
        {
            return new MutualManaRecoveryEffect(this);
        }

        public override string ToString()
        {
            return $"Return ${Amount} cards from your mana zone to your hand. Then your opponent chooses ${Amount} cards in his mana zone and returns them to his hand.";
        }
    }
}