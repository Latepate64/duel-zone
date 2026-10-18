using Interfaces;

namespace Cards;

public class PlayerHasNoShieldsCondition : ICondition
{
    public bool IsMet(IPlayerV2 player)
    {
        return !player.ShieldZone.HasCards;
    }
}