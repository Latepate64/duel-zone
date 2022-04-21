using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ThisCreatureGetsBlockerUntilTheEndOfTheTurnOneShotEffect : OneShotEffect
    {
        public ThisCreatureGetsBlockerUntilTheEndOfTheTurnOneShotEffect(ThisCreatureGetsBlockerUntilTheEndOfTheTurnOneShotEffect effect) : base(effect)
        {
        }

        public ThisCreatureGetsBlockerUntilTheEndOfTheTurnOneShotEffect() : base()
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ThisCreatureGetsBlockerUntilTheEndOfTheTurnOneShotEffect(this);
        }

        public override string ToString()
        {
            return "This creature gets \"blocker\" until the end of the turn.";
        }

        public override void Apply(IGame game)
        {
            game.AddContinuousEffects(GetSourceAbility(game), new ContinuousEffects.ThisCreatureGetsBlockerUntilTheEndOfTheTurnContinuousEffect(game.GetCard(GetSourceAbility(game).Source)));
        }
    }
}
