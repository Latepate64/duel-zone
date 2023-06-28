using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    class EachOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect : OneShotEffect, IPowerable
    {
        public EachOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(int power) : base()
        {
            Power = power;
        }

        public EachOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(EachOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
            Power = effect.Power;
        }

        public int Power { get; }

        public override void Apply()
        {
            Game.AddContinuousEffects(Ability, new ContinuousEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(Power, Game.BattleZone.GetCreatures(Applier).ToArray()));
        }

        public override IOneShotEffect Copy()
        {
            return new EachOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(this);
        }

        public override string ToString()
        {
            return $"Each of your creatures in the battle zone gets +{Power} power until the end of the turn.";
        }
    }
}
