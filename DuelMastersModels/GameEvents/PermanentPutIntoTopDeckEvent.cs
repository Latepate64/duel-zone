namespace DuelMastersModels.GameEvents
{
    public class PermanentPutIntoTopDeckEvent : GameEvent
    {
        public Player Player { get; }
        public Permanent Permanent { get; }

        public PermanentPutIntoTopDeckEvent(Player player, Permanent permanent)
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
