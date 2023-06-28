using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    class AuraBlastEffect : OneShotEffect, IPowerable
    {
        public AuraBlastEffect(int power) : base()
        {
            Power = power;
        }

        public AuraBlastEffect(AuraBlastEffect effect) : base(effect)
        {
            Power = effect.Power;
        }

        public int Power { get; }

        public override void Apply(IGame game)
        {
            game.AddContinuousEffects(Ability, new ContinuousEffects.ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect(Power, game.BattleZone.GetCreatures(Applier).ToArray()));
        }

        public override IOneShotEffect Copy()
        {
            return new AuraBlastEffect(this);
        }

        public override string ToString()
        {
            return $"Each of your creatures in the battle zone gets \"power attacker +{Power}\" until the end of the turn.";
        }
    }
}
