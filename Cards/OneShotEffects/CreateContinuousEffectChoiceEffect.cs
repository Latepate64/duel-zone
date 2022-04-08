using Cards.CardFilters;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    abstract class CreateContinuousEffectChoiceEffect : CardSelectionEffect
    {
        public IEnumerable<ContinuousEffect> ContinuousEffects { get; }

        protected CreateContinuousEffectChoiceEffect(CreateContinuousEffectChoiceEffect effect) : base(effect)
        {
            ContinuousEffects = effect.ContinuousEffects;
        }

        protected CreateContinuousEffectChoiceEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses, params ContinuousEffect[] effects) : base(filter, minimum, maximum, controllerChooses)
        {
            ContinuousEffects = effects;
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            foreach (var effect in ContinuousEffects)
            {
                game.AddContinuousEffects(source, effect.Copy());
            }
        }
    }
}
