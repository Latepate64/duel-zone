using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect : OneShotEffect, IPowerable
    {
        public int Power { get; }

        public ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(int power)
        {
            Power = power;
        }

        public ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
            Power = effect.Power;
        }

        public override IOneShotEffect Copy()
        {
            return new ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(this);
        }

        public override void Apply(IGame game)
        {
            game.AddContinuousEffects(Ability, new ContinuousEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(Power, game.GetCard(Ability.Source)));
        }

        public override string ToString()
        {
            return $"This creature gets +{Power} power until the end of the turn.";
        }
    }
}
