namespace Engine.GameEvents
{
    public class ShieldsBrokenEvent : GameEvent
    {
        public ShieldsBrokenEvent(ICard attacker, int breakAmount)
        {
            Attacker = attacker;
            BreakAmount = breakAmount;
        }

        public ICard Attacker { get; }
        public int BreakAmount { get; }

        public override void Happen(IGame game)
        {
            var owner = game.GetPlayer(Attacker.Owner);
            var opponent = game.GetOpponent(owner);
            var cards = owner.ChooseCards(opponent.ShieldZone.Cards, BreakAmount, BreakAmount, "Choose shields to break.");
            game.PutFromShieldZoneToHand(cards, true);
        }

        public override string ToString()
        {
            return $"{Attacker} broke {BreakAmount} shields.";
        }
    }
}
