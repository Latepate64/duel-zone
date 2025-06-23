using Engine.Abilities;
using Interfaces;

namespace TriggeredAbilities;

public abstract class CardTriggeredAbility : TriggeredAbility
{
    protected CardTriggeredAbility(IOneShotEffect effect) : base(effect)
    {
    }

    protected CardTriggeredAbility(CardTriggeredAbility ability) : base(ability)
    {
    }

    protected abstract bool TriggersFrom(ICreature card, IGame game);
}
