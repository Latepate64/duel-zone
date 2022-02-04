namespace Common.GameEvents
{
    public class SpellCastEvent : GameEvent
    {
        public Player Player { get; set; }
        public Card Spell { get; set; }

        public SpellCastEvent()
        {
        }

        public override string ToString()
        {
            return $"{Player} cast {Spell}.";
        }
    }
}
