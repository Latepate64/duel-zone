using Interfaces;

namespace GameEvents;

public sealed class ShieldsBreakEvent(IEnumerable<ICard> shields) : ShieldsMightBreakEvent(shields)
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
