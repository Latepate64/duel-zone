using Engine.GameEvents;
using Interfaces;
using System.Collections.Generic;

namespace GameEvents;

public sealed class GlaisMejiculaEvent(
    IEnumerable<ICard> remainingShields, IEnumerable<ICard> discard, IAbility ability) : GameEvent
{
    private readonly IAbility _ability = ability;
    private readonly IEnumerable<ICard> _discard = discard;
    private readonly IEnumerable<ICard> _remainingShields = remainingShields;

    public override void Happen(IGame game)
    {
        game.Move(_ability, ZoneType.Hand, ZoneType.Graveyard, [.. _discard]);
        game.PutFromShieldZoneToHand(_remainingShields, true, null);
    }

    public override string ToString()
    {
        throw new System.NotImplementedException();
    }
}
