namespace Common.GameEvents
{
    public class BattleEvent : GameEvent
    {
        public Card Creature1 { get; set; }
        public Card Creature2 { get; set; }

        public BattleEvent()
        {
            //Text = $"{game.GetOwner(Creature1)}'s {Creature1} ({Creature1.Power}) battled {game.GetOwner(Creature2)}'s {Creature2} ({Creature2.Power}).";
        }
    }
}
