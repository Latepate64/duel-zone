namespace Common.GameEvents
{
    public class BlockEvent : GameEvent
    {
        public Card Attacker { get; set; }
        public Card Blocker { get; set; }

        public BlockEvent()
        {
            //Text = $"{game.GetOwner(Blocker)}'s {Blocker} blocked {game.GetOwner(Attacker)}'s {Attacker}.";
        }
    }
}
