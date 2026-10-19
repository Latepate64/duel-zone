using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.CanAttackUntappedCreatures;

/// <summary>
/// Each of your creatures in the battle zone that can attack creatures can
/// attack untapped creatures this turn.
/// </summary>
public sealed class RumbleGateContinuousEffect : UntilEndOfTurnEffect,
    ICanAttackUntappedCreaturesEffect
{
    public RumbleGateContinuousEffect() : base()
    {
    }

    public RumbleGateContinuousEffect(RumbleGateContinuousEffect effect) : base(effect)
    {
    }

    public bool CanAttackUntappedCreature(ICreature attacker, ICreature targetOfAttack, IGame game)
    {
        return Applier.Equals(attacker.OwnerV2) && game.CanAttackAtLeastOneCreature(attacker);
    }

    public override IContinuousEffect Copy()
    {
        return new RumbleGateContinuousEffect(this);
    }
}
