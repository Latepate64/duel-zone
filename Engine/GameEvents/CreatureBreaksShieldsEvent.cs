using System.Collections.Generic;

namespace Engine.GameEvents
{
    public sealed class CreatureBreaksShieldsEvent(ICreature attacker, int breakAmount) :
        CreatureMightBreakShieldsEvent(attacker, breakAmount)
    {
        public override void Happen(IGame game)
        {
            var owner = Attacker.Owner;
            var cards = owner.ChooseCards(game.GetOpponent(owner).ShieldZone.Cards, BreakAmount, BreakAmount, "Choose shields to break.");
            game.ProcessEvents(new ShieldsBreakEvent(cards));
        }

        public override string ToString()
        {
            return $"{Attacker} broke {BreakAmount} shields.";
        }
    }

    public abstract class CreatureMightBreakShieldsEvent(ICreature attacker, int breakAmount) : GameEvent
    {
        public ICreature Attacker { get; } = attacker;
        public int BreakAmount { get; } = breakAmount;
    }

    public abstract class ShieldsMightBreakEvent(IEnumerable<ICard> shields) : GameEvent
    {
        public IEnumerable<ICard> Shields { get; } = shields;
    }

    public class ShieldsBreakEvent(IEnumerable<ICard> shields) : ShieldsMightBreakEvent(shields)
    {
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
