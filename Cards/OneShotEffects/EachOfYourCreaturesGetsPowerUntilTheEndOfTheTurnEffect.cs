using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    class EachOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect : OneShotAreaOfEffect
    {
        private readonly int _power;

        public EachOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(int power) : base()
        {
            _power = power;
        }

        public EachOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(EachOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
        }

        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new ContinuousEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(_power, game.BattleZone.GetCreatures(source.Controller).ToArray()));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new EachOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(this);
        }

        public override string ToString()
        {
            return $"Each of your creatures in the battle zone gets +{_power} power until the end of the turn.";
        }
    }
}
