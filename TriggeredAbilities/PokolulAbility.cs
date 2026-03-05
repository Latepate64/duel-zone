using Interfaces;

namespace TriggeredAbilities;

public sealed class PokolulAbility : TriggeredAbility
{
    public PokolulAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public PokolulAbility(PokolulAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        throw new System.NotImplementedException();
        // return gameEvent is ShieldTriggerEvent e && e.Player == GetOpponent(game) && game.CurrentTurn.CurrentPhase is AttackPhase phase && phase.AttackingCreature == Source;
    }

    public override IAbility Copy()
    {
        return new PokolulAbility(this);
    }

    public override string ToString()
    {
        return "Whenever your opponent uses the \"shield trigger\" ability of a shield broken by this creature, you may untap this creature.";
    }
}
