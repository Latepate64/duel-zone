namespace DuelMastersModels.GameEvents
{
    public class PermanentPutIntoTopDeckEvent : GameEvent
    {
        public Player Player { get; }
        public Card Permanent { get; }

        public PermanentPutIntoTopDeckEvent(Player player, Card permanent)
        {
            Player = player;
            Permanent = permanent;
        }

        public override string ToString(Duel duel)
        {
            return $"{Player} put {Permanent} from the battle zone on top of their deck.";
        }
    }
}
