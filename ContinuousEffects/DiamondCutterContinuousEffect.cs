using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

/// <summary>
/// This turn, ignore any effects that would prevent your creatures from
/// attacking your opponent.
/// </summary>
public sealed class DiamondCutterContinuousEffect : UntilEndOfTurnEffect,
    IIgnoreCannotAttackPlayersEffects
{
    public DiamondCutterContinuousEffect() : base()
    {
    }

    public DiamondCutterContinuousEffect(
        DiamondCutterContinuousEffect effect) : base(effect)
    {
    }

    public bool IgnoreCannotAttackPlayersEffects(ICreature attacker, IGame game)
    {
        return Applier.Equals(attacker.OwnerV2);
    }

    public override IContinuousEffect Copy()
    {
        return new DiamondCutterContinuousEffect(this);
    }
}
