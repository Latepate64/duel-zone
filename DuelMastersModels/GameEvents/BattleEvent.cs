namespace DuelMastersModels.GameEvents
{
    public class BattleEvent : GameEvent
    {
        public Card Creature1 { get; set; }
        public Card Creature2 { get; set; }

        public BattleEvent(Card creature1, Card creature2, Game game)
        {
            Creature1 = creature1;
            Creature2 = creature2;
            Text = $"{game.GetOwner(Creature1)}'s {Creature1} ({Creature1.Power}) battled {game.GetOwner(Creature2)}'s {Creature2} ({Creature2.Power}).";
        }
    }
}
