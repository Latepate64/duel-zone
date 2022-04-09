using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
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

        protected CreateContinuousEffectChoiceEffect(int minimum, int maximum, bool controllerChooses, params ContinuousEffect[] effects) : base(minimum, maximum, controllerChooses)
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
