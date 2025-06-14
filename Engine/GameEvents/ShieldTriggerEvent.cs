namespace Engine.GameEvents
{
    public class ShieldTriggerEvent(IPlayer player, Card trigger) : GameEvent
    {
        public IPlayer Player { get; } = player;
        public Card Trigger { get; } = trigger;

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
