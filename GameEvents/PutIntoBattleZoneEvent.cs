using Interfaces;

namespace GameEvents;

public sealed class PutIntoBattleZoneEvent(IPlayerV2 player, bool passable, ICard card) :
    MoveCardEvent(player, ZoneType.BattleZone, passable)
{
    public ICard ICard { get; } = card;

    internal override ICard RemoveCardFromCurrentZone()
    {
        Player.Hand.Remove(ICard); // TODO: May not be in hand always
        return ICard;
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is PutIntoBattleZoneEvent e
            && ICard == e.ICard;
    }
}