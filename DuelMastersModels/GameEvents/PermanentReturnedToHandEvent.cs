namespace DuelMastersModels.GameEvents
{
    public class PermanentReturnedToHandEvent : GameEvent
    {
        public Player Player { get; }
        public Permanent Permanent { get; }

        public PermanentReturnedToHandEvent(Player player, Permanent permanent)
        {
            Player = player;
            Permanent = permanent;
        }

        public override string ToString(Duel duel)
        {
            return $"{Player} returned {Permanent} from the battle zone to their hand.";
        }
    }
}
