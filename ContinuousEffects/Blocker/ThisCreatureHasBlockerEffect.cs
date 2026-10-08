using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.Blocker;

/// <summary>
/// Blocker (Whenever an opponent's creature attacks, you may tap this creature
/// to stop the attack. Then the 2 creatures battle.)
/// </summary>
public sealed class ThisCreatureHasBlockerEffect : ContinuousEffect,
    IBlockerEffect
{
    public ThisCreatureHasBlockerEffect() : base()
    {
    }

    public ThisCreatureHasBlockerEffect(
        ThisCreatureHasBlockerEffect effect) : base(effect)
    {
    }

    public bool CanBlock(ICreature blocker, ICreature attacker)
    {
        if (!IsSourceOfAbility(blocker)) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureHasBlockerEffect(this);
    }
}