using Cards.CardFilters;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    class CreateContinuousEffectChoiceEffect : CardSelectionEffect
    {
        public IEnumerable<ContinuousEffect> ContinuousEffects { get; }

        public CreateContinuousEffectChoiceEffect(CreateContinuousEffectChoiceEffect effect) : base(effect)
        {
            ContinuousEffects = effect.ContinuousEffects;
        }

        public CreateContinuousEffectChoiceEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses, params ContinuousEffect[] effects) : base(filter, minimum, maximum, controllerChooses)
        {
            ContinuousEffects = effects;
        }

        public override IOneShotEffect Copy()
        {
            return new CreateContinuousEffectChoiceEffect(this);
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            foreach (var effect in ContinuousEffects)
            {
                var copy = effect.Copy();
                copy.Filter = new TargetsFilter(cards);
                game.AddContinuousEffects(source, copy);
            }
        }

        public override string ToString()
        {
            return $"{(ControllerChooses ? "Choose" : "Your opponent chooses")} {GetAmountAsText()} {Filter}. {string.Join(", ", ContinuousEffects)}.";
        }
    }
}
