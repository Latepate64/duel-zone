using System.Linq;

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
            var cards = owner.Choose(new Common.Choices.ShieldBreakSelection(owner.Id, opponent.ShieldZone.Cards, BreakAmount), game).Decision.Select(x => game.GetCard(x));
            game.PutFromShieldZoneToHand(cards, true);
        }

        public override string ToString()
        {
            throw new System.NotImplementedException();
        }
    }
}
