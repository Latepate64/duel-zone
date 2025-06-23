using Interfaces;

namespace Engine.GameEvents;

public sealed class CreatureBreaksShieldsEvent(ICreature attacker, int breakAmount) :
    CreatureMightBreakShieldsEvent(attacker, breakAmount)
{
    public override void Happen(IGame game)
    {
        var owner = Attacker.Owner;
        var cards = owner.ChooseCards(
            game.GetOpponent(owner).ShieldZone.Cards, BreakAmount, BreakAmount, "Choose shields to break.");
        game.ProcessEvents(new ShieldsBreakEvent(cards));
    }

    public override string ToString()
    {
        return $"{Attacker} broke {BreakAmount} shields.";
    }
}
