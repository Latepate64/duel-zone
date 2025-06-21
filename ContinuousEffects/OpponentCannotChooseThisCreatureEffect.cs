using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class OpponentCannotChooseThisCreatureEffect : ContinuousEffect, IPlayerCannotChooseCreatureEffect
{
    public OpponentCannotChooseThisCreatureEffect() : base()
    {
    }

    public bool PlayerCannotChooseCreature(ICreature creature, System.Guid player, IGame game)
    {
        return IsSourceOfAbility(creature) && player == game.GetOpponent(Controller).Id;
    }

    public override IContinuousEffect Copy()
    {
        return new OpponentCannotChooseThisCreatureEffect();
    }

    public override string ToString()
    {
        return "Whenever your opponent would choose a creature in the battle zone, he can't choose this one.";
    }
}
