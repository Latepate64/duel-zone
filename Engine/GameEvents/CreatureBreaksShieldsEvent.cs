using System.Collections.Generic;

namespace Engine.GameEvents
{
    public sealed class CreatureBreaksShieldsEvent : CreatureMightBreakShieldsEvent
    {
        public CreatureBreaksShieldsEvent(ICard attacker, int breakAmount) : base(attacker, breakAmount)
        {
        }

        public override void Happen(IGame game)
        {
            var owner = game.GetPlayer(Attacker.Owner);
            var cards = owner.ChooseCards(game.GetOpponent(owner).ShieldZone.Cards, BreakAmount, BreakAmount, "Choose shields to break.");
            game.ProcessEvents(new ShieldsBreakEvent(cards));
        }

        public override string ToString()
        {
            return $"{Attacker} broke {BreakAmount} shields.";
        }
    }

    public abstract class CreatureMightBreakShieldsEvent : GameEvent
    {
        public ICard Attacker { get; }
        public int BreakAmount { get; }

        protected CreatureMightBreakShieldsEvent(ICard attacker, int breakAmount)
        {
            Attacker = attacker;
            BreakAmount = breakAmount;
        }
    }

    public abstract class ShieldsMightBreakEvent : GameEvent
    {
        public IEnumerable<ICard> Shields { get; }

        protected ShieldsMightBreakEvent(IEnumerable<ICard> shields)
        {
            Shields = shields;
        }
    }

    public class ShieldsBreakEvent : ShieldsMightBreakEvent
    {
        public ShieldsBreakEvent(IEnumerable<ICard> shields) : base(shields)
        {
        }

        public override void Happen(IGame game)
        {
            game.PutFromShieldZoneToHand(Shields, true, null);
        }

        public override string ToString()
        {
            return $"{Shields} were broken.";
        }
    }
}
