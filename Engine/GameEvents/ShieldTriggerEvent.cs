namespace Engine.GameEvents
{
    public class ShieldTriggerEvent : GameEvent
    {
        public ShieldTriggerEvent(IPlayer player, ICard trigger)
        {
            Player = player;
            Trigger = trigger;
        }

        public IPlayer Player { get; }
        public ICard Trigger { get; }

        public override void Happen(IGame game)
        {
            if (game.CanBeUsedRegardlessOfManaCost(Trigger))
            {
                Player.UseCard(Trigger);
            }
        }

        public override string ToString()
        {
            return $"{Player} used shield trigger: {Trigger}";
        }
    }
}
