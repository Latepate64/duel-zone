using Interfaces;

namespace OneShotEffects;

public abstract class TapAreaOfEffect : OneShotEffect
{
    protected TapAreaOfEffect()
    {
    }

    protected TapAreaOfEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var cards = GetAffectedCards(game, Ability).ToArray();
        Controller.Tap(game, cards);
    }

    protected abstract IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source);
}
