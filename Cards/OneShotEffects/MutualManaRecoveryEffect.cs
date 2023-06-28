using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    abstract class MutualManaRecoveryEffect : OneShotEffect
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

        public override void Apply()
        {
            Applier.ReturnOwnManaCards(Ability, Amount);
            Applier.Opponent.ReturnOwnManaCards(Ability, Amount);
        }
    }
}