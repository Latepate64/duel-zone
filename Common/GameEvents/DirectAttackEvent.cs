namespace Common.GameEvents
{
    public class DirectAttackEvent : GameEvent
    {
        public IPlayer Player { get; set; }

        public DirectAttackEvent()
        {
        }

        public override string ToString()
        {
            return $"{Player} was directly attacked.";
        }
    }
}
