using Engine.Abilities;
using Engine.GameEvents;
using Interfaces;
using System;
using System.Linq;

namespace TriggeredAbilities;

public sealed class WingeyeMothAbility : LinkedTriggeredAbility
{
    public WingeyeMothAbility() : base()
    {
    }

    public WingeyeMothAbility(LinkedTriggeredAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is PhaseBegunEvent e && e.Phase.Type == Engine.Steps.PhaseOrStep.Draw
            && e.Turn.ActivePlayer == Controller && InterveningIfClauseValid(game);
    }

    public override IAbility Copy()
    {
        return new WingeyeMothAbility(this);
    }

    public override void Resolve(IGame game)
    {
        if (InterveningIfClauseValid(game))
        {
            Controller.DrawCardsOptionally(game, this, 1);
        }
    }

    public override string ToString()
    {
        return "Whenever your draw the card at the start of your turn, if one of your creatures in the battle zone has higher power then each of your opponent's creatures in the battle zone, you may draw an extra card.";
    }

    public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
    {
        return new WingeyeMothAbility(this);
    }

    private bool InterveningIfClauseValid(IGame game)
    {
        var strongest = game.BattleZone.Creatures.Where(x => x.Power == game.BattleZone.Creatures.Max(x => x.Power));
        return strongest.Any() && strongest.All(x => x.Owner == Controller);

    }
}
