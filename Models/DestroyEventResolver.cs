using Interfaces;

namespace Models;

public class DestroyEventResolver : EventResolver<DestroyEvent>
{
    public override IEnumerable<OneShotEffect> Resolve(
        IGameState state, IPlayerV2 applier, DestroyEvent gameEvent)
    {
        var cards = state.BattleZone.Remove(gameEvent.Creature);
        foreach (var card in cards)
        {
            card.OwnerV2.Graveyard.Add(card);
        }
        return [];
    }
}