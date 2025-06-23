using Engine.GameEvents;
using Interfaces;

namespace TriggeredAbilities;

public sealed class CopperLocustAbility : TriggeredAbility
{
    public CopperLocustAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public CopperLocustAbility(CopperLocustAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is EvolutionEvent;
    }

    public override IAbility Copy()
    {
        return new CopperLocustAbility(this);
    }

    public override string ToString()
    {
        return $"When a player evolves another creature, {GetEffectText()}";
    }
}
