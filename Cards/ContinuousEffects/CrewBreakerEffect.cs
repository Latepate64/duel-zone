using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    abstract class CrewBreakerEffect : ContinuousEffect, IBreakerEffect
    {
        protected CrewBreakerEffect(CrewBreakerEffect effect) : base(effect)
        {
        }

        protected CrewBreakerEffect() : base()
        {
            
        }

        public abstract int GetAmount(IGame game, ICard creature);
    }

    class CrewBreakerRaceEffect : CrewBreakerEffect
    {
        private readonly Race _race;

        public CrewBreakerRaceEffect(CrewBreakerRaceEffect effect) : base(effect)
        {
            _race = effect._race;
        }

        public CrewBreakerRaceEffect(Race race) : base()
        {
            _race = race;
        }

        public override string ToString()
        {
            return $"Crew breaker - {_race}";
        }

        public override int GetAmount(IGame game, ICard creature)
        {
            var ability = Source;
            return IsSourceOfAbility(creature, game) ? game.BattleZone.GetCreatures(ability.Controller).Count(x => x.Id != ability.Source && x.HasRace(_race)) : 1;
        }

        public override IContinuousEffect Copy()
        {
            return new CrewBreakerRaceEffect(this);
        }
    }
}
