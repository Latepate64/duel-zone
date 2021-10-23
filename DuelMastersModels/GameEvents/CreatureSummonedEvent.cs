namespace DuelMastersModels.GameEvents
{
    public class CreatureSummonedEvent : GameEvent
    {
        public Player Player { get; }
        public Card Creature { get; }

        public CreatureSummonedEvent(Player player, Card creature)
        {
            Player = player;
            Creature = creature;
        }

        public override string ToString(Duel duel)
        {
            return $"{Player} summoned {Creature}.";
        }
    }
}
