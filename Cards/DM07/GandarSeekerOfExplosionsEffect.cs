using Engine.Abilities;
using Interfaces;

namespace Cards.DM07;

public sealed class GandarSeekerOfExplosionsEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        throw new System.NotImplementedException();
        // game.AddDelayedTriggeredAbility(
        //     new AtTheEndOfTheTurnDelayedTriggeredAbility(
        //         Ability,
        //         game.CurrentTurn.Id,
        //         new GandarSeekerOfExplosionsUntapEffect()));
    }

    public override IOneShotEffect Copy()
    {
        return new GandarSeekerOfExplosionsEffect();
    }

    public override string ToString()
    {
        return "At the end of the turn, untap all your light creatures.";
    }
}
