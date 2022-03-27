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

        protected LookEffect(CardFilter filter, int minimum, int maximum) : base(filter, minimum, maximum, true)
        {
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            if (cards.Any())
            {
                var revealer = game.GetOwner(cards.First());
                source.GetController(game).Look(revealer, game, cards);
                revealer.Unreveal(cards);
            }
        }
    }
}