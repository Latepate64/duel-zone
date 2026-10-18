using Interfaces;

namespace TriggeredAbilities;

public sealed class AfterAttackAbility : TriggeredAbility
{
    public ICreature Attacker { get; }

    public AfterAttackAbility(IOneShotEffect effect, ICreature attacker) : base(effect)
    {
        Attacker = attacker;
    }

    public AfterAttackAbility(AfterAttackAbility ability) : base(ability)
    {
        Attacker = ability.Attacker;
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
        // return gameEvent is CreatureStoppedAttackingEvent e && e.AttackingCreature.Id == Attacker;
    }

    public override IAbility Copy()
    {
        return new AfterAttackAbility(this);
    }
}
