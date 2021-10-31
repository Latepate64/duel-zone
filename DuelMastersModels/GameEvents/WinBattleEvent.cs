namespace DuelMastersModels.GameEvents
{
    public class WinBattleEvent : GameEvent
    {
        public Permanent Creature { get; }

        public WinBattleEvent(Permanent creature)
        {
            Creature = creature;
        }

        public override string ToString(Duel duel)
        {
            return $"{duel.GetOwner(Creature)}'s {Creature} won the battle.";
        }
    }
}
