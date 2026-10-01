using Interfaces;

namespace TriggeredAbilities;

public sealed class WheneverAnyOfYourCreaturesFinishesAttackingAbility : TriggeredAbility
{
    public WheneverAnyOfYourCreaturesFinishesAttackingAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public WheneverAnyOfYourCreaturesFinishesAttackingAbility(
        WheneverAnyOfYourCreaturesFinishesAttackingAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
        // return gameEvent is CreatureStoppedAttackingEvent e && e.AttackingCreature.Owner == Controller;
    }

    public override IAbility Copy()
    {
        return new WheneverAnyOfYourCreaturesFinishesAttackingAbility(this);
    }

    public override string ToString()
    {
        return "Whenever any of your creatures finishes attacking, you may draw 2 cards for each shield it broke.";
    }
}
