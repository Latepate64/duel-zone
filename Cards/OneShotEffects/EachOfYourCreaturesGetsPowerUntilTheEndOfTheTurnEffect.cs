using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    class EachOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect : OneShotEffect
    {
        private readonly int _power;

        public EachOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(int power) : base()
        {
            _power = power;
        }

        public EachOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(EachOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            game.AddContinuousEffects(Source, new ContinuousEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(_power, game.BattleZone.GetCreatures(Source.Controller).ToArray()));
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
