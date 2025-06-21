using Engine;
using Engine.Abilities;

namespace OneShotEffects;

public abstract class BreaksOpponentsShieldsEffect : OneShotEffect
{
    protected readonly int _amount;

    protected BreaksOpponentsShieldsEffect(BreaksOpponentsShieldsEffect effect)
    {
        _amount = effect._amount;
    }

    protected BreaksOpponentsShieldsEffect(int amount = 1)
    {
        _amount = amount;
    }

    public override void Apply(IGame game)
    {
        game.Break(GetBreaker(game, Ability), _amount);
    }

    protected abstract ICreature GetBreaker(IGame game, IAbility source);
}
