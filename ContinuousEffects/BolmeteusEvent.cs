using GameEvents;
using Interfaces;

namespace ContinuousEffects;

public sealed class BolmeteusEvent(ICreature attacker, int breakAmount) : CreatureMightBreakShieldsEvent(attacker, breakAmount)
{
    public override void Happen(IGame game)
    {
        var owner = Attacker.Owner;
        var cards = owner.ChooseCards(game.GetOpponent(owner).ShieldZone.Cards, BreakAmount, BreakAmount, "Choose shields. Your opponent puts those shields into his graveyard.");
        game.Move(null, ZoneType.ShieldZone, ZoneType.Graveyard, [.. cards]);
    }

    public override string ToString()
    {
        return $"Opponent put {BreakAmount} shields into his graveyard.";
    }
}
