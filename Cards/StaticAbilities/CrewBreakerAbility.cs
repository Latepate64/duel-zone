using Common;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.StaticAbilities
{
    class CrewBreakerAbility : Engine.Abilities.StaticAbility
    {
        public CrewBreakerAbility(Subtype subtype) : base(new CrewBreakerEffect(subtype))
        {
        }
    }

    class CrewBreakerEffect : BreakerEffect
    {
        private readonly Subtype _subtype;

        public CrewBreakerEffect(CrewBreakerEffect effect) : base(effect)
        {
        }

        public CrewBreakerEffect(Subtype subtype) : base(new Durations.Indefinite())
        {
            _subtype = subtype;
        }

        public override IContinuousEffect Copy()
        {
            return new CrewBreakerEffect(this);
        }

        public override int GetAmount(Engine.IGame game)
        {
            var ability = game.GetAbility(SourceAbility);
            return game.BattleZone.GetCreatures(ability.Controller).Count(x => x.Id != ability.Source && x.Subtypes.Contains(_subtype));
        }

        public override string ToString()
        {
            return $"Crew breaker - {_subtype}";
        }
    }
}