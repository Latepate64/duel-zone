namespace DuelMastersModels.GameEvents
{
    public class PermanentPutIntoManaZone : GameEvent
    {
        public Player Player { get; }
        public Permanent Permanent { get; }

        public PermanentPutIntoManaZone(Player player, Permanent permanent)
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
