using Common;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    abstract class CrewBreakerEffect : BreakerEffect
    {
        protected CrewBreakerEffect(CrewBreakerEffect effect) : base(effect)
        {
        }

        protected CrewBreakerEffect() : base(new Durations.Indefinite())
        {
            
        }
    }

    class CrewBreakerSubtypeEffect : CrewBreakerEffect
    {
        private readonly Subtype _subtype;

        public CrewBreakerSubtypeEffect(CrewBreakerSubtypeEffect effect) : base(effect)
        {
            _subtype = effect._subtype;
        }

        public CrewBreakerSubtypeEffect(Subtype subtype) : base()
        {
            _subtype = subtype;
        }

        public override string ToString()
        {
            return $"Crew breaker - {_subtype}";
        }

        public override int GetAmount(Engine.IGame game)
        {
            var ability = game.GetAbility(SourceAbility);
            return game.BattleZone.GetCreatures(ability.Controller).Count(x => x.Id != ability.Source && x.Subtypes.Contains(_subtype));
        }

        public override IContinuousEffect Copy()
        {
            return new CrewBreakerSubtypeEffect(this);
        }
    }
}
