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

        public override void Apply(IGame game)
        {
            Controller.ReturnOwnManaCards(game, Ability, Amount);
            game.GetOpponent(Controller).ReturnOwnManaCards(game, Ability, Amount);
        }
    }
}