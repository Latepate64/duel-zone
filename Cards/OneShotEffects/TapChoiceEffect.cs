using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    abstract class TapChoiceEffect : CardSelectionEffect
    {
        protected TapChoiceEffect(int minimum, int maximum, bool ownerChooses) : base(minimum, maximum, ownerChooses)
        {
        }

        protected TapChoiceEffect(TapChoiceEffect effect) : base(effect)
        {
        }

        protected override void Apply(IAbility source, params ICard[] cards)
        {
            (ControllerChooses ? Applier : Applier.Opponent).Tap(cards);
        }
    }
}