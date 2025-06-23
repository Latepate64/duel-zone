using Engine.Abilities;
using Engine.GameEvents;
using Interfaces;

namespace TriggeredAbilities;

public sealed class WheneverOneOfYourRaceBlocksAbility : TriggeredAbility
{
    readonly Race[] races;

    public WheneverOneOfYourRaceBlocksAbility(IOneShotEffect effect, params Race[] races) : base(effect)
    {
        this.races = races;
    }

    WheneverOneOfYourRaceBlocksAbility(WheneverOneOfYourRaceBlocksAbility ability) : base(ability)
    {
        races = [..ability.races];
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is BecomeBlockedEvent e && e.Blocker.Owner == Controller && e.Blocker.HasRace(races);
    }

    public override IAbility Copy()
    {
        return new WheneverOneOfYourRaceBlocksAbility(this);
    }

    public override string ToString()
    {
        return $"Whenever one of your {string.Join(" or ", races.Select(r => r + "s"))} blocks, {GetEffectText()}";
    }
}
