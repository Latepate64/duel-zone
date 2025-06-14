namespace Engine.GameEvents
{
    public class ShieldTriggerEvent : GameEvent
    {
        public ShieldTriggerEvent(IPlayer player, Card trigger)
        {
            Player = player;
            Trigger = trigger;
        }

        public IPlayer Player { get; }
        public Card Trigger { get; }

        public override void Happen(IGame game)
        {
            if (game.CanBeUsedRegardlessOfManaCost(Trigger))
            {
                Player.UseCard(Trigger, game);
            }
        }

        public override string ToString()
        {
            return $"{Player} used shield trigger: {Trigger}";
        }
    }
}
