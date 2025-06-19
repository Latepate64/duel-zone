using Engine;
using Engine.GameEvents;
using System.Collections.Generic;

namespace Cards.ContinuousEffects;

public class WhenOneOfYourShieldsWouldBeBrokenYouMayDestroyThisCreatureInsteadEvent(Creature creature, IEnumerable<Card> remainingShields) : GameEvent
{
    private readonly Creature _creature = creature;
    private readonly IEnumerable<Card> _remainingShields = remainingShields;

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
