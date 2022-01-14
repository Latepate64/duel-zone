namespace DuelMastersModels.GameEvents
{
    public class PermanentPutIntoManaZone : GameEvent
    {
        public Player Player { get; }
        public Card Permanent { get; }

        public PermanentPutIntoManaZone(Player player, Card permanent)
        {
            Player = player;
            Permanent = permanent;
        }

        public override string ToString(Duel duel)
        {
            return $"{Player} put {Permanent} from the battle zone into their mana zone.";
        }
    }
}
