using GameEvents;
using Interfaces;

namespace ContinuousEffects;

public sealed class WhenOneOfYourShieldsWouldBeBrokenYouMayDestroyThisCreatureInsteadEvent(ICreature creature, IEnumerable<ICard> remainingShields) : GameEvent
{
    private readonly ICreature _creature = creature;
    private readonly IEnumerable<ICard> _remainingShields = remainingShields;

    public override void Happen(IGame game)
    {
        game.Destroy(null, _creature);
        game.PutFromShieldZoneToHand(_remainingShields, true, null);
    }

    public override string ToString()
    {
        throw new System.NotImplementedException();
    }
}
