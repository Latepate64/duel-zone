using Interfaces;
using Interfaces.Zones;

namespace Models;

public class MoveCardEventResolver : EventResolver<MoveCardEvent>
{
    public override IEnumerable<OneShotEffect> Resolve(
        IGameState state, IPlayer applier, MoveCardEvent gameEvent)
    {
        var cards = new List<ICard>();
        if (gameEvent.Source == ZoneType.Battlezone)
        {
            cards.AddRange(state.BattleZone.Remove(gameEvent.Card));
        }
        foreach (var card in cards)
        {
            GetZone(gameEvent.Destination, card.OwnerV2).Add(card);
        }
        return [];
    }

    private static IZone GetZone(ZoneType zoneType, IPlayer player)
    {
        return zoneType switch
        {
            ZoneType.Graveyard => player.Graveyard,
            ZoneType.Hand => player.Hand,
            ZoneType.Manazone => player.ManaZone,
            ZoneType.Shieldzone => player.ShieldZone,
            ZoneType.Deck => player.Deck,
            _ => throw new NotImplementedException()
        };
    }
}