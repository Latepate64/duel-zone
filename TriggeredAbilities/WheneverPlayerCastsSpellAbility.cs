using Engine.Abilities;
using GameEvents;
using Interfaces;

namespace TriggeredAbilities;

public sealed class WheneverPlayerCastsSpellAbility : TriggeredAbility
{
    public WheneverPlayerCastsSpellAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public WheneverPlayerCastsSpellAbility(WheneverPlayerCastsSpellAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is SpellCastEvent;
    }

    public override IAbility Copy()
    {
        return new WheneverPlayerCastsSpellAbility(this);
    }

    public override string ToString()
    {
        return $"Whenever a player casts a spell, {GetEffectText()}";
    }
}
