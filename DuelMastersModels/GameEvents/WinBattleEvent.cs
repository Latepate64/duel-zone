namespace DuelMastersModels.GameEvents
{
    public class WinBattleEvent : GameEvent
    {
        public Card Creature { get; }

        public WinBattleEvent(Card creature)
        {
            Creature = creature;
        }

        public override string ToString(Game game)
        {
            return $"{game.GetOwner(Creature)}'s {Creature} won the battle.";
        }
    }
}
