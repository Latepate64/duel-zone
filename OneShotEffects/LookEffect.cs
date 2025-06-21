using Engine;
using Engine.Abilities;

namespace OneShotEffects;

public abstract class LookEffect : CardSelectionEffect<ICard>
{
    protected LookEffect(LookEffect effect) : base(effect)
    {
    }

    protected LookEffect(int minimum, int maximum) : base(minimum, maximum, true)
    {
    }

    protected override void Apply(IGame game, IAbility source, params ICard[] cards)
    {
        if (cards.Length != 0)
        {
            var revealer = game.GetOwner(cards.First());
            Controller.Look(revealer, game, cards);
            revealer.Unreveal(cards);
        }
    }
}
