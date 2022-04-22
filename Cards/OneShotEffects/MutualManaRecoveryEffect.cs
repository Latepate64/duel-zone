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

        public override void Apply(IGame game)
        {
            var controller = Controller;
            controller.ReturnOwnManaCards(game, Ability, Amount);
            game.GetOpponent(controller).ReturnOwnManaCards(game, Ability, Amount);
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
}