using Engine.Abilities;
using Engine.GameEvents;
using System;
using System.Linq;
using Interfaces;

namespace Cards.DM09;

public sealed class FistsOfForeverAbility : LinkedTriggeredAbility
{
    private readonly ICreature _creature;

    public FistsOfForeverAbility(ICreature creature)
    {
        _creature = creature;
    }

    public FistsOfForeverAbility(FistsOfForeverAbility ability) : base(ability)
    {
        _creature = ability._creature;
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is BattleEvent e && e.Winners.Contains(_creature);
    }

    public override IAbility Copy()
    {
        return new FistsOfForeverAbility(this);
    }

    public override void Resolve(IGame game)
    {
        Controller.Untap(game, _creature);
    }

    public override string ToString()
    {
        return $"Whenever {_creature} wins a battle this turn, untap it.";
    }

    public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
    {
        return new FistsOfForeverAbility(this);
    }
}
