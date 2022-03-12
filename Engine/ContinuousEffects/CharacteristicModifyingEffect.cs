using Engine.Durations;
using System.Collections.Generic;
using System.Linq;

namespace Engine.ContinuousEffects
{
    public abstract class CharacteristicModifyingEffect : ContinuousEffect
    {
        private readonly List<Condition> _conditions = new();

        protected CharacteristicModifyingEffect(CardFilter filter, Duration duration, params Condition[] conditions) : base(filter, duration)
        {
            _conditions.AddRange(conditions);
        }

        protected CharacteristicModifyingEffect(CharacteristicModifyingEffect effect) : base(effect)
        {
            _conditions = effect._conditions.ToList(); //TODO: Implement copy?
        }

        internal virtual void CheckConditionsAndApply(Game game)
        {
            var source = game.GetAbility(SourceAbility);
            if (source != null)
            {
                var player = game.GetPlayer(source.Owner);
                if (player != null && _conditions.All(x => x.Applies(game, player.Id)))
                {
                    Apply(game);
                }
            }
        }

        public abstract void Apply(Game game);

        protected string ToStringBase()
        {
            if (_conditions.Any())
            {
                return string.Join(" and ", _conditions) + " ,";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
