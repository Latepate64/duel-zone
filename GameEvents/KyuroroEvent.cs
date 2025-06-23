using Engine.GameEvents;
using Interfaces;

namespace GameEvents;

public sealed class KyuroroEvent(ICreature attacker, int breakAmount) : CreatureMightBreakShieldsEvent(
    attacker, breakAmount)
{
    public override void Happen(IGame game)
    {
        var opponent = game.GetOpponent(Attacker.Owner);
        var cards = opponent.ChooseCards(opponent.ShieldZone.Cards, BreakAmount, BreakAmount, "Choose shields to break.");
        game.PutFromShieldZoneToHand(cards, true, null);
    }

    public override string ToString()
    {
        return $"{Attacker} broke {BreakAmount} shields.";
    }
}
