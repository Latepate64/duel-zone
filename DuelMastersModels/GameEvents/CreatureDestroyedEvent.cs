namespace DuelMastersModels.GameEvents
{
    public class CreatureDestroyedEvent : GameEvent
    {
        public Permanent Creature { get; }

        public CreatureDestroyedEvent(Permanent creature)
        {
            Creature = creature;
        }

        public override string ToString(Duel duel)
        {
            return $"{duel.GetOwner(Creature)}'s {Creature} was destroyed.";
        }
    }
}
