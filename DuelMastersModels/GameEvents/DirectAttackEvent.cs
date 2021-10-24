namespace DuelMastersModels.GameEvents
{
    public class DirectAttackEvent : GameEvent
    {
        public Player Player { get; }

        public DirectAttackEvent(Player player)
        {
            Player = player;
        }

        public override string ToString(Duel duel)
        {
            return $"{Player} was directly attacked.";
        }
    }
}
