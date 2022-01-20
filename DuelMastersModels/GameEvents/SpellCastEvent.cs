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

        public override string ToString(Game game)
        {
            return $"{Player} cast {Spell}.";
        }
    }
}
