using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    class ThisCreatureGetsBlockerUntilTheEndOfTheTurnOneShotEffect : OneShotAreaOfEffect
    {
        public ThisCreatureGetsBlockerUntilTheEndOfTheTurnOneShotEffect(ThisCreatureGetsBlockerUntilTheEndOfTheTurnOneShotEffect effect) : base(effect)
        {
        }

        public ThisCreatureGetsBlockerUntilTheEndOfTheTurnOneShotEffect() : base(new TargetFilter())
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

        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new ContinuousEffects.ThisCreatureGetsBlockerUntilTheEndOfTheTurnContinuousEffect(GetAffectedCards(game, source).ToArray()));
            return null;
        }
    }
}
