using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect : OneShotEffect
    {
        private readonly int _power;

        public ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(int power)
        {
            _power = power;
        }

        public ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
            _power = effect._power;
        }

        public override IOneShotEffect Copy()
        {
            return new ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(this);
        }

        public override void Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new ContinuousEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(_power, game.GetCard(source.Source)));
        }

        public override string ToString()
        {
            return "This creature gets +3000 power until the end of the turn.";
        }
    }
}
