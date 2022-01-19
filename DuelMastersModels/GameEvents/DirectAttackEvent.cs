namespace DuelMastersModels.GameEvents
{
    public class DirectAttackEvent : GameEvent
    {
        public Player Player { get; }

        public DirectAttackEvent(Player player)
        {
            Player = player;
        }

        public override string ToString(Game game)
        {
            return $"{Player} was directly attacked.";
        }
    }
}
