using Engine.Abilities;
using Interfaces;

namespace Cards.DM10;

public class DeklowazTheTerminatorEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        Controller.DestroyAllCreaturesThatHaveMaximumPower(3000, game, Ability);
        Controller.LookAtOpponentsHand(game);
        GetOpponent(game).DiscardAllCreaturesThatHaveMaximumPower(3000, game, Ability);
    }

    public override IOneShotEffect Copy()
    {
        return new DeklowazTheTerminatorEffect();
    }

    public override string ToString()
    {
        return "Destroy all creatures that have power 3000 or less. Then look at your opponent's hand. He discards all creatures from it that have power 3000 or less.";
    }
}
