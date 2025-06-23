using ContinuousEffects;
using Engine.Abilities;
using Engine.GameEvents;
using Interfaces;

namespace TriggeredAbilities;

public sealed class CreepingPlagueTriggeredAbility : LinkedTriggeredAbility
{
    private ICreature _creature;

    public CreepingPlagueTriggeredAbility()
    {
    }

    public CreepingPlagueTriggeredAbility(CreepingPlagueTriggeredAbility ability) : base(ability)
    {
        _creature = ability._creature;
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is BecomeBlockedEvent e && e.Attacker == Source && Controller == Source.Owner;
    }

    public override IAbility Copy()
    {
        return new CreepingPlagueTriggeredAbility(this);
    }

    public override void Resolve(IGame game)
    {
        game.AddContinuousEffects(this, new CreatureGetsSlayerUntilEndOfTheTurnEffect(_creature));
    }

    public override string ToString()
    {
        return "Whenever any of your creatures becomes blocked, it gets \"slayer\" until the end of the turn.";
    }

    public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
    {
        _creature = (gameEvent as BecomeBlockedEvent).Attacker;
        return Copy() as ITriggeredAbility;
    }
}
