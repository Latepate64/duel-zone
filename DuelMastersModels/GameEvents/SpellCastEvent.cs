namespace DuelMastersModels.GameEvents
{
    public class SpellCastEvent : GameEvent
    {
        public Player Player { get; }
        public Card Spell { get; }

        public SpellCastEvent(Player player, Card spell)
        {
            Player = player;
            Spell = spell;
        }

        public override string ToString(Duel duel)
        {
            return $"{Player} cast {Spell}.";
        }
    }
}
