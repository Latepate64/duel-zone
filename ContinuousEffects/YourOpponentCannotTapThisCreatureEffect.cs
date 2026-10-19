using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class YourOpponentCannotTapThisCreatureEffect : ContinuousEffect, IPlayerCannotTapCreatureEffect
{
    public YourOpponentCannotTapThisCreatureEffect()
    {
    }

    public YourOpponentCannotTapThisCreatureEffect(YourOpponentCannotTapThisCreatureEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new YourOpponentCannotTapThisCreatureEffect(this);
    }

    public bool PlayerCannotTapCreature(IPlayer player, ICreature creature, IGame game)
    {
        return player == game.GetOpponent(Controller) && IsSourceOfAbility(creature);
    }

    public override string ToString()
    {
        return "Your opponent can't tap this creature.";
    }
}
