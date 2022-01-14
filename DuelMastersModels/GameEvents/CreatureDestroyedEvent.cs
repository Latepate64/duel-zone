namespace DuelMastersModels.GameEvents
{
    public class CreatureDestroyedEvent : GameEvent
    {
        public Card Creature { get; }

        public CreatureDestroyedEvent(Card creature)
        {
            Creature = creature;
        }

        public override string ToString(Duel duel)
        {
            return $"{duel.GetOwner(Creature)}'s {Creature} was destroyed.";
        }
    }
}
