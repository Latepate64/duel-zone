using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

/// <summary>
/// Whenever your opponent would choose a creature in the battle zone, he can't
/// choose this one.
/// </summary>
public sealed class OpponentCannotChooseThisCreatureEffect : ContinuousEffect,
    IPlayerCannotChooseCreatureEffect
{
    public OpponentCannotChooseThisCreatureEffect() : base()
    {
    }

    public override IContinuousEffect Copy()
    {
        return new OpponentCannotChooseThisCreatureEffect();
    }

    public bool PlayerCannotChooseCreature(
        ICreature creature, IPlayerV2 player, IGame game)
    {
        if (!IsSourceOfAbility(creature)) return false;
        if (!player.Equals(Applier.Opponent)) return false;
        return true;
    }
}
