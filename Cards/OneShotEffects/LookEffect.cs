using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    abstract class LookEffect : CardSelectionEffect
    {
        protected LookEffect(LookEffect effect) : base(effect)
        {
        }

        protected LookEffect(int minimum, int maximum) : base(minimum, maximum, true)
        {
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            if (cards.Any())
            {
                var revealer = cards.First().Owner;
                Applier.Look(revealer, cards);
                revealer.Unreveal(cards);
            }
        }
    }
}