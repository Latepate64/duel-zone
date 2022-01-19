namespace DuelMastersModels.GameEvents
{
    public class BattleEvent : GameEvent
    {
        public Card Creature1 { get; set; }
        public int Creature1Power { get; set; }
        public Card Creature2 { get; set; }
        public int Creature2Power { get; set; }

        public BattleEvent(Card creature1, int creature1Power, Card creature2, int creature2Power)
        {
            Creature1 = creature1;
            Creature1Power = creature1Power;
            Creature2 = creature2;
            Creature2Power = creature2Power;
        }

        public override string ToString(Game game)
        {
            return $"{game.GetOwner(Creature1)}'s {Creature1} ({Creature1Power}) battled {game.GetOwner(Creature2)}'s {Creature2} ({Creature2Power}).";
        }
    }
}
