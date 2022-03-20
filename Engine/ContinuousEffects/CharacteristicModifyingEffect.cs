﻿using Engine.Durations;

namespace Engine.ContinuousEffects
{
    public abstract class CharacteristicModifyingEffect : ContinuousEffect
    {
        protected CharacteristicModifyingEffect(ICardFilter filter, IDuration duration, params Condition[] conditions) : base(filter, duration, conditions)
        {
        }

        protected CharacteristicModifyingEffect(CharacteristicModifyingEffect effect) : base(effect)
        {
        }

        internal virtual void CheckConditionsAndApply(Game game)
        {
            if (ConditionsApply(game))
            {
                Apply(game);
            }
        }

        public abstract void Apply(Game game);
    }
}
