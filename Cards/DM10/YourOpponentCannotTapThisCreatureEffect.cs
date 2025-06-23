using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM10;

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
        return player == GetOpponent(game) && IsSourceOfAbility(creature);
    }

    public override string ToString()
    {
        return "Your opponent can't tap this creature.";
    }
}
