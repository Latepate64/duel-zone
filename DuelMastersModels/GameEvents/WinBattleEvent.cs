namespace DuelMastersModels.GameEvents
{
    public class WinBattleEvent : GameEvent
    {
        public Card Creature { get; }

        public WinBattleEvent(Card creature)
        {
            Creature = creature;
        }

        public override string ToString(Duel duel)
        {
            return $"{duel.GetOwner(Creature)}'s {Creature} won the battle.";
        }
    }
}
