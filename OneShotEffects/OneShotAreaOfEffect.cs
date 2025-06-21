using Engine;
using Engine.Abilities;

namespace OneShotEffects;

public abstract class OneShotAreaOfEffect : OneShotEffect
{
    protected OneShotAreaOfEffect()
    {
    }

    protected OneShotAreaOfEffect(OneShotAreaOfEffect effect) : base(effect)
    {
    }

    protected abstract IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source);
}
