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

        public abstract int GetAmount(ICard creature);
    }

    class CrewBreakerRaceEffect : CrewBreakerEffect, IRaceable
    {
        public Race Race { get; }

        public CrewBreakerRaceEffect(CrewBreakerRaceEffect effect) : base(effect)
        {
            Race = effect.Race;
        }

        public CrewBreakerRaceEffect(Race race) : base()
        {
            Race = race;
        }

        public override string ToString()
        {
            return $"Crew breaker - {Race}";
        }

        public override int GetAmount(ICard creature)
        {
            return IsSourceOfAbility(creature) ? Game.BattleZone.GetCreatures(Applier).Count(x => !IsSourceOfAbility(x) && x.HasRace(Race)) : 1;
        }

        public override IContinuousEffect Copy()
        {
            return new CrewBreakerRaceEffect(this);
        }
    }
}
