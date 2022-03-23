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

        public override object Apply(IGame game, IAbility source)
        {
            foreach (var effect in new OneShotEffect[] { new SelfManaRecoveryEffect(Amount, Amount, true, new CardFilters.OwnersManaZoneCardFilter()), new OpponentManaRecoveryEffect(Amount, Amount, false)})
            {
                effect.Apply(game, source);
            }
            return null;
        }

        public override OneShotEffect Copy()
        {
            return new MutualManaRecoveryEffect(this);
        }

        public override string ToString()
        {
            return $"Return {Amount} cards from your mana zone to your hand. Then your opponent chooses {Amount} cards in his mana zone and returns them to his hand.";
        }
    }
}