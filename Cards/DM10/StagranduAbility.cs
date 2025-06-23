using TriggeredAbilities;
using Engine;
using Engine.GameEvents;
using Interfaces;

namespace Cards.DM10;

public sealed class StagranduAbility : WheneverThisCreatureAttacksAbility
{
    public StagranduAbility() : base(new OneShotEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(9000))
    {
    }

    public StagranduAbility(StagranduAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        return base.CanTrigger(gameEvent, game) && gameEvent is CreatureAttackedEvent e
            && e.Target is Creature c && c.Power >= 6000;
    }
}
