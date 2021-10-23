namespace DuelMastersModels.GameEvents
{
    public class PutIntoBattleZoneEvent : GameEvent
    {
        public Card Card { get; }
        public Player Player { get; }

        public PutIntoBattleZoneEvent(Card card, Player player)
        {
            Card = card;
            Player = player;
        }

        public override string ToString(Duel duel)
        {
            return $"{Player} put {Card} into the battle zone.";
        }
    }
}
