using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    class AuraBlastEffect : OneShotEffect
    {
        private readonly int _power;

        public AuraBlastEffect(int power) : base()
        {
            _power = power;
        }

        public AuraBlastEffect(AuraBlastEffect effect) : base(effect)
        {
            _power = effect._power;
        }

        public override void Apply(IGame game)
        {
            game.AddContinuousEffects(GetSourceAbility(game), new ContinuousEffects.ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect(_power, game.BattleZone.GetCreatures(GetSourceAbility(game).Controller).ToArray()));
        }

        public override IOneShotEffect Copy()
        {
            return new AuraBlastEffect(this);
        }

        public override string ToString()
        {
            return $"Each of your creatures in the battle zone gets \"power attacker +{_power}\" until the end of the turn.";
        }
    }
}
