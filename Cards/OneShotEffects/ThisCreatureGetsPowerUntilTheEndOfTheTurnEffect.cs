using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect : OneShotEffect
    {
        public override IOneShotEffect Copy()
        {
            return new ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect();
        }

        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new ContinuousEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(3000, game.GetCard(source.Source)));
            return null;
        }

        public override string ToString()
        {
            return "This creature gets +3000 power until the end of the turn.";
        }
    }
}
