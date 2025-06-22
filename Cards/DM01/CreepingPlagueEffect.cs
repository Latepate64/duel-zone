using TriggeredAbilities;
using Engine.Abilities;
using Interfaces;

namespace Cards.DM01;

public class CreepingPlagueEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        game.AddDelayedTriggeredAbility(new WheneverSomethingHappensThisTurnAbility(
            new CreepingPlagueTriggeredAbility(), Ability));
    }

    public override IOneShotEffect Copy()
    {
        return new CreepingPlagueEffect();
    }

    public override string ToString()
    {
        return "Whenever any of your creatures becomes blocked this turn, it gets \"slayer\" until the end of the turn.";
    }
}
