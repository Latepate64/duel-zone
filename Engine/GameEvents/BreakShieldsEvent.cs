namespace Engine.GameEvents
{
    public sealed class BreakShieldsEvent : MightBreakShieldsEvent
    {
        public BreakShieldsEvent(ICard attacker, int breakAmount) : base(attacker, breakAmount)
        {
        }

        public override void Happen(IGame game)
        {
            var owner = game.GetPlayer(Attacker.Owner);
            var cards = owner.ChooseCards(game.GetOpponent(owner).ShieldZone.Cards, BreakAmount, BreakAmount, "Choose shields to break.");
            game.PutFromShieldZoneToHand(cards, true);
        }

        public override string ToString()
        {
            return $"{Attacker} broke {BreakAmount} shields.";
        }
    }

    public abstract class MightBreakShieldsEvent : GameEvent
    {
        public ICard Attacker { get; }
        public int BreakAmount { get; }

        protected MightBreakShieldsEvent(ICard attacker, int breakAmount)
        {
            Attacker = attacker;
            BreakAmount = breakAmount;
        }
    }
}
